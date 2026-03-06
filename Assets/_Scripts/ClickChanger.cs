using UnityEngine; // Подключаем базовый функционал Unity

// [RequireComponent...] — это атрибут. Он говорит Unity: 
// "Если этого компонента нет на объекте, добавь его автоматически".
[RequireComponent(typeof(SpriteRenderer))]
public class ClickChanger : MonoBehaviour // Имя класса должно совпадать с именем файла!
{
    // Ссылка на компонент рендерера (отвечает за отрисовку)
    private SpriteRenderer _spriteRenderer;

    // 1. Создаем переменную для хранения состояния (увеличен или нет)
    private bool _isBig = false;

    // 2. Запоминаем исходный размер, чтобы можно было вернуть
    private Vector3 _startScale;

    private void Awake()
    {
        Debug.Log("Скрипт проснулся!");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startScale = transform.localScale; // Запоминаем размер при старте
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 3. Переключаем состояние на противоположное
            _isBig = !_isBig;

            // 4. Применяем размер в зависимости от состояния
            if (_isBig)
            {
                transform.localScale = _startScale * 1.5f; // Увеличиваем в 1.5 раза
            }
            else
            {
                transform.localScale = _startScale; // Возвращаем как было
            }

            Debug.Log("Масштаб изменен!");
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