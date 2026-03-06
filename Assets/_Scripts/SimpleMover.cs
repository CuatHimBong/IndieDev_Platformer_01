using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float _speed = 5f; // Скорость движения

    private void Update()
    {
        // 1. Получаем ввод по горизонтали (A/D или Стрелки)
        // Возвращает значение от -1 (влево) до 1 (вправо). 0 если ничего не нажато.
        float horizontalInput = Input.GetAxis("Horizontal");

        // 2. Вычисляем направление движения
        // Vector3.right — это вектор (1, 0, 0), то есть "вправо"
        Vector3 direction = Vector3.right * horizontalInput;

        // 3. Двигаем объект
        // Translate перемещает трансформ на заданное расстояние
        // Time.deltaTime — это время между кадрами. Нужно, чтобы скорость не зависела от FPS!
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}