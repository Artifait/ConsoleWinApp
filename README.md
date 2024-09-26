# **Мини фраймворк для создание приложений в консоли**
## МиниТест Возможностей. Ниже вся нужная информация для запуска и теста

После клонирования создайте, локальную БазуДанных 
c Названием Fruits, после запустите ниже приведёный скрипт. 

```
CREATE TABLE FruitsAndVegetables ( 
Id INT PRIMARY KEY IDENTITY(1,1), 
Name NVARCHAR(100) NOT NULL, 
Type NVARCHAR(50) NOT NULL, 
Color NVARCHAR(50) NOT NULL, 
Calories INT NOT NULL 
); 

INSERT INTO FruitsAndVegetables (Name, Type, Color, Calories) VALUES
('Apple', 'Fruit', 'Red', 52),
('Banana', 'Fruit', 'Yellow', 89),
('Carrot', 'Vegetable', 'Orange', 41),
('Broccoli', 'Vegetable', 'Green', 34),
('Strawberry', 'Fruit', 'Red', 32),
('Spinach', 'Vegetable', 'Green', 23),
('Orange', 'Fruit', 'Orange', 47),
('Cucumber', 'Vegetable', 'Green', 16),
('Grapes', 'Fruit', 'Purple', 69),
('Potato', 'Vegetable', 'Brown', 77),
('Watermelon', 'Fruit', 'Green', 30),
('Tomato', 'Fruit', 'Red', 18),
('Bell Pepper', 'Vegetable', 'Yellow', 20),
('Lettuce', 'Vegetable', 'Green', 15),
('Blueberry', 'Fruit', 'Blue', 57),
('Onion', 'Vegetable', 'White', 40),
('Peach', 'Fruit', 'Orange', 39),
('Zucchini', 'Vegetable', 'Green', 17),
('Pear', 'Fruit', 'Green', 57),
('Pumpkin', 'Vegetable', 'Orange', 26);
```
