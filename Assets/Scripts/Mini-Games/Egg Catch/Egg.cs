using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {
    public Game game;        // Скрипт с логикой игры
    public GameObject[] egg; // Массив яиц
    public int spawn;        // Номер спавна
    public int step = 0;     // Номер шага

    // Инициализация
	void Start () {
        // Запускаем корутин
        StartCoroutine(Steps());
	}
	
    // Обновление кадра
	void Update () {
        // Если яйцо падает, а корзина возле нашего спавна
        if (step == 5 && game.playerPos == spawn) {
            // Выполняем функцию "Count" из скрипта "Game"
            game.Count();
            // Скрываем объект на сцене
            egg[4].SetActive(false);
            // Удаляем игроой объект, отвечающий за текущее яйцо
            Destroy(this.gameObject);
        }
	}

    // Корутин, отвечающий за перемещение яиц
    IEnumerator Steps() {
        // Если это первый шаг
        if (step == 0) {
            // Включаем яйцо, соответствующее текущему шагу
            egg[step].SetActive(true);
        // Если это 11 шаг
        } else if (step == 10) {
            // Удаляем игровой объект, отечающий за это яйцо
            Destroy(this.gameObject);
        // Иначе
        } else {
            // Включаем яйцо, соответствующее текущему шагу
            egg[step].SetActive(true);
            // Выключаем предыдущее яйцо
            egg[step - 1].SetActive(false);
            // Если этот шаг соответствует разбивающемуся яйцу, выполняем 
            // функцию "Crash" из скрипта "Game"
            if (step == 5) game.Crash();
            // Иначе выполняем функцию "Stap" из скрипта "Game"
            else game.Step();
        }
        // Но в любом случае:
        // Прибавляем к переменной "step" единичку
        step++;
        // Ожидаем в течении "time" из скрипта "Game"
        yield return new WaitForSeconds(game.time);
        // Перезапускаем корутин
        StartCoroutine(Steps());
    }
}
