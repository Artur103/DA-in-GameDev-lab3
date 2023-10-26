# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #3 выполнил:
- Хаврак Артур Юрьевич
- ФО-220007
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

## Цель работы
Разработать оптимальный баланс для десяти уровней игры Dragon Picker

## Задание 1
### Предложите вариант изменения найденных переменных для 10 уровней в игре. Визуализируйте изменение уровня сложности в таблице.
- Вот список переменных для балансировки уровней:
  1. Скорость
  2. Время между появлением яиц
  3. Минимальная дистанция до края
  4. Шанс смены направления движения
- Ссылка на таблицу с данными и их визуализацией: https://docs.google.com/spreadsheets/d/1t51tbdECzuv2HCd7WMHwYR2gLQ8H2v0-Y-4a_cksxWg/edit?usp=sharing

## Задание 2
### Создайте 10 сцен на Unity с изменяющимся уровнем сложности.
- Я создал класс, который хранит индекс загруженного уровня. Это нужно для того, чтобы понимать, какие использовать значения из таблицы.
- Создал меню для выбора уровней

## Задание 3
### Решение в 80+ баллов должно заполнять google-таблицу данными из Python. В Python данные также должны быть визуализированы.

- Вот код, в котором хранятся значения для каждого уровня.

```py

import math
import gspread
import numpy as np
from matplotlib import pyplot as plt 

gc = gspread.service_account(filename='da-in-gamedev-lab3-338b5f58c6db.json')
sh = gc.open("DA-in-GameDev-lab3")

levels = [i for i in range(1, 11)]

def load_into_table(values, start_index):
      for i in range(len(values)):
            sh.sheet1.update(chr(ord(start_index[0]) + i) + str(int(start_index[1:])), values[i])
            print(chr(ord(start_index[0]) + i) + str(int(start_index[1:])), values[i])

speed_array = [1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5]
plt.plot(levels, speed_array)  
plt.title("Dragon Speed")
plt.show()
speed_table_start = "A3"

time_between_egg_drop_array = [1, 0.95, 0.9, 0.85, 0.8, 0.75, 0.7, 0.65, 0.6, 0.55]
plt.plot(levels, time_between_egg_drop_array)  
plt.title("Time between egg drop")
plt.show()
time_between_egg_drop_table_start = "L3"

left_right_distance_array = [10, 9.5, 9, 8.5, 8, 7.5, 7, 6.5, 6, 5.5]
plt.plot(levels, left_right_distance_array)  
plt.title("Dragon Left Right distance")
plt.show()
left_right_distance_table_start = "A23"

chance_direction_array = [0.1, 0.125, 0.15, 0.175, 0.2, 0.225, 0.25, 0.275, 0.3, 0.325]
plt.plot(levels, chance_direction_array)  
plt.title("Chance direction")
plt.show()
chance_direction_table_start = "L23"

load_into_table(speed_array, speed_table_start)
load_into_table(time_between_egg_drop_array, time_between_egg_drop_table_start)
load_into_table(left_right_distance_array, left_right_distance_table_start)
load_into_table(chance_direction_array, chance_direction_table_start)

```

## Выводы

Я изучил прототип игры Dragon Picker, обозначил переменные, пригодные для изменения уровня сложности, реализовал перенос данных из Python в Google Sheets и из Google Sheets в Unity, а также визуалировала данные для балансировки игры.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
