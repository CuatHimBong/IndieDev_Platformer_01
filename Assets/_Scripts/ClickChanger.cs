using UnityEngine; // Подключаем базовый функционал Unity

// [RequireComponent...] — это атрибут. Он говорит Unity: 
// "Если этого компонента нет на объекте, добавь его автоматически".
[RequireComponent(typeof(SpriteRenderer))]
public class ClickChanger : MonoBehaviour // Имя класса должно совпадать с именем файла!
{
    // Ссылка на компонент рендерера (отвечает за отрисовку)
    private SpriteRenderer _spriteRenderer;

    // Awake вызывается ОДИН РАЗ при создании объекта в сцене.
    // Идеальное место для поиска компонентов и инициализации.
    private void Awake()
    {
        Debug.Log("Скрипт проснулся!");
        // GetComponent<T>() — ищет компонент типа T на ЭТОМ же объекте.
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Если нажал Пробел — меняем цвет
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Пробел нажат! Цвет меняется.");
            _spriteRenderer.color = Random.ColorHSV();
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("Мышь наведена на объект!");
    }

    // OnMouseDown — это "магический" метод Unity.
    // Он вызывается АВТОМАТИЧЕСКИ, когда ты кликаешь мышкой по объекту.
    // Тебе не нужно вызывать его вручную!
    private void OnMouseDown()
    {
        // Меняем цвет рендерера на случайный
        _spriteRenderer.color = Random.ColorHSV();

        // Выводим сообщение в консоль (удобно для отладки)
        Debug.Log("Клик по объекту! Цвет изменен.");
    }
}