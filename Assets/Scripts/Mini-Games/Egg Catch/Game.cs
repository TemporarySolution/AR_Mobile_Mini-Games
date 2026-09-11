using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject zero;   // Пустой GameObject

    // Положения игрока
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public int playerPos;    // Текущее положение игрока

    [HideInInspector]
    public Transform egg;    // Временная переменная, для заполнения массивов яиц

    // Массивы яиц для каждого спавна
    [HideInInspector]
    public GameObject[] egg1;
    [HideInInspector]
    public GameObject[] egg2;
    [HideInInspector]
    public GameObject[] egg3;
    [HideInInspector]
    public GameObject[] egg4;

    public float time = 1;   // Скорость игры
    public int count;        // Счётчик собранных яиц
    public int hp;           // Счётчик потеряных яиц

    public TextMesh counter; // Объект счётчика

    // Объекты иконок потеряных яиц
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;

    // Объект надписи "Нажмите, чтобы начать
    public GameObject pressStart;

    // Звуки
    public AudioSource soundStep;
    public AudioSource soundCrash;
    public AudioSource soundCount;

    // Игра запущена?
    public bool isPlaying = false;

    // Инициализация
    void Start() {
        // Присваиваем временной переменной трансформ объекта "Спавн 1"
        egg = GameObject.Find("Spawn1").transform;
        // Задаём размер массива
        egg1 = new GameObject[10];
        // Заполняем массив дочерними объектами от первого спавна
        for (int i = 0; i < egg.childCount; i++) egg1[i] = egg.Find(i.ToString()).gameObject;

        // Три строки далее - заполняют массив второго спавна
        egg = GameObject.Find("Spawn2").transform;
        egg2 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg2[i] = egg.Find(i.ToString()).gameObject;

        // Три строки далее - заполняют массив третьего спавна
        egg = GameObject.Find("Spawn3").transform;
        egg3 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg3[i] = egg.Find(i.ToString()).gameObject;

        // Три строки далее - заполняют массив четвёртого спавна
        egg = GameObject.Find("Spawn4").transform;
        egg4 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg4[i] = egg.Find(i.ToString()).gameObject;

        // Скрываем отображение волка на сцене
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        // Скрываем отображение яиц на сцене
        foreach (GameObject eg in egg1) eg.SetActive(false);
        foreach (GameObject eg in egg2) eg.SetActive(false);
        foreach (GameObject eg in egg3) eg.SetActive(false);
        foreach (GameObject eg in egg4) eg.SetActive(false);
    }

    // Перед обновлением кадра
    void Update() {
        // Если игрок нажимает левый шифт
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            // Сообщаем, что игрок занимает позицию "1" (лево верх)
            playerPos = 1;
            // Включаем отображение олка, ловящего яйцо с первого спавна
            player1.SetActive(true);
            // И отключаем остальные
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
        } if (Input.GetKeyDown(KeyCode.RightShift)) {
            playerPos = 2;
            player1.SetActive(false);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
        } if (Input.GetKeyDown(KeyCode.LeftControl)) {
            playerPos = 3;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(true);
            player4.SetActive(false);
        } if (Input.GetKeyDown(KeyCode.RightControl)) {
            playerPos = 4;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(true);
        }
        //Если игрок нажимает пробел
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Если игра была запущена - останавливаем
            if (isPlaying) StopGame();
            // Иначе - запускаем игру
            else StartGame();
        }
    }
    public void StartEnder()
    {
        // Если игра была запущена - останавливаем
        if (isPlaying) StopGame();
        // Иначе - запускаем игру
        else StartGame();
    }



    public void SetPos(int pos)
    {
        playerPos = pos;
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        if (pos == 1)
        {
            player1.SetActive(true);
        }
        else if (pos == 2)
        {
            player2.SetActive(true);
        }
        else if (pos == 3)
        {
            player3.SetActive(true);
        }
        else { player4.SetActive(true); }
    }

    // Корутин, задающий скорость игры
    IEnumerator Timer() {
        // Создаём на сцене копию пустого объекта
        GameObject egg = Instantiate(zero);
        // Добавляем на него скрипт "Egg"
        Egg comp = egg.AddComponent<Egg>();
        // В переменную "game" компонента "Egg" передаём данный скрипт "Game"
        comp.game = this.GetComponent<Game>();
        // Выбираем произвольное число от 1 до 4 и передаём его в переменную спавн
        comp.spawn = Random.Range(1, 5);
        // Заполняем массив в переменной "egg" яйцами с того спавна, что выдал рандом
        if (comp.spawn == 1) comp.egg = egg1;
        if (comp.spawn == 2) comp.egg = egg2;
        if (comp.spawn == 3) comp.egg = egg3;
        if (comp.spawn == 4) comp.egg = egg4;
        // Ждём в течении времени, указанного в переменной "time"
        yield return new WaitForSeconds(time);
        // Перезапускаем корутин
        StartCoroutine(Timer());
    }

    // Воспроизводим звук "шага"
    public void Step() { soundStep.Play(); }
    public void Count() {
        // Добавляем к счётчику единицу
        count++;
        // Обновляем счётчик
        counter.text = count.ToString();
        // Воспроизводим звук пойманного яйца
        soundCount.Play();
    }
    public void Crash() {
        // Добавляем единицу к счётчику не пойманых яиц
        hp++;
        // Воспроизводим звук "разбивания" яйца
        soundCrash.Play();
        // Включаем индикаторы "потеряных" яиц в зависимости от их числа
        if (hp >= 1) hp1.SetActive(true);
        if (hp >= 2) hp2.SetActive(true);
        if (hp >= 3) hp3.SetActive(true);
        // Если потеряли больше трёх яиц - останавливаем игру
        if (hp > 3) StopGame();
    }

    // Запускаем игру
    void StartGame() {
        // Сообщаем, что игра запущена
        isPlaying = true;
        // Скрываем надпись "нажмите, чтобы начать"
        pressStart.SetActive(false);

        // Сообщаем, что игрок находится в первом положении
        playerPos = 1;
        // Включаем первый объект игрока
        player1.SetActive(true);
        // А остальные отключаем
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        // Обнуляем счётчики
        count = 0;
        hp = 0;

        // Скрываем индикатор потеряных яиц
        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);

        // Запускаем корутин
        StartCoroutine(Timer());
    }

    // Останавливаем игру
    void StopGame() {
        // Сообщаем, что игра остановлена
        isPlaying = false;
        // Останавливаем корутины
        StopAllCoroutines();

        // Скрываем все яйца со сцены
        foreach (GameObject eg in egg1) eg.SetActive(false);
        foreach (GameObject eg in egg2) eg.SetActive(false);
        foreach (GameObject eg in egg3) eg.SetActive(false);
        foreach (GameObject eg in egg4) eg.SetActive(false);
        // Скрываем игрока
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        // Отображаем надпись
        pressStart.SetActive(true);

        // Создаём массив GameObject-ов поиском по тегу "zero"
        GameObject[] eggsArray = GameObject.FindGameObjectsWithTag("zero");
        // Перебираем массив и, если имя "Egg(Clone)" - удаляем объект
        foreach (GameObject eg in eggsArray) if (eg.name == "Egg(Clone)") Destroy(eg);
    }
}
