﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace OneHundredAndEighty
{
    public class Player //  Класс игрока
    {
        public string Name; //  Имя игрока
        public string Tag;  //  Тэг

        //Матч
        public int LegsWon; //  Количество выигранных легов
        public int SetsWon; //  Количество выигранных сетов
        public int PointsToOut; //  Количество очков на завершение сета

        //Очередной подход
        public int HandPoints;  //  Набранное количестов очков
        public Throw Throw1 = new Throw();  //  Первый бросок
        public Throw Throw2 = new Throw();  //  Второй бросок
        public Throw Throw3 = new Throw();  //  Третий бросок
        public void ClearHand() //  Обнуление очередного подхода
        {
            this.HandPoints = 0;
            this.Throw1.ClearThrow();
            this.Throw2.ClearThrow();
            this.Throw3.ClearThrow();
        }

        //  Инфо-панель
        public Canvas HelpPanel;    //  Панель помощи
        public Label HelpLabel; //  Лейбл помощи
        public Label SetsWonLabel;  //  Лейбл выиграных сетов
        public Label LegsWonLabel;  //  Лейбл выиграных легов
        public Label PointsLabel;   //  Лейбл набраных очнов
        public Ellipse DotPoint;    //  Точка начала сета

        public Player(string Tag, string Name, Canvas HelpPanel, Label HelpLabel, Label SetsWonLabel, Label LegsWonLabel, Label PointsLabel, Ellipse DotPoint, int PointsToOut) //  Конструктор нового игрока
        {
            this.Tag = Tag;
            this.Name = Name;
            this.HelpPanel = HelpPanel;
            this.HelpLabel = HelpLabel;
            this.SetsWonLabel = SetsWonLabel;
            this.LegsWonLabel = LegsWonLabel;
            this.PointsLabel = PointsLabel;
            this.DotPoint = DotPoint;
            this.PointsToOut = PointsToOut;
        }
    }
}
