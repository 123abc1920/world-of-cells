using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Russian : Language
{
    public Russian(){
        Title = "Мир Клеток";
        Play = "Играть";
        Settings = "Настройки";
        Cards = "Карты";
        Story = "История";

        SettingsTitle = "Настройки";
        ProgressLbl = "Прогресс: {0}";
        ProgressBtn = "Сброс";
        SoundLbl = "Звук";
        SoundBtn = "Btn";
        LanguageLbl = "Язык";
        LanguageBtn = "Рус";

        CardsTitle = "Собранные Карты";
        ProgressTitle = "Вы собрали {0}% карт";

        Tree = "Дерево: ";
        Water = "Вода: ";
        Rock = "Камни: ";
        Steps = "Шаги: ";
        StartNewGame = "Начать заново";
        SkipStep = "Пропустить шаг";
        BuildBridge = "Строить мост";
        BuildHut = "Строить дом";
        BackToMenu = "Назад";

        Ok = "Принять";
        Close = "Закрыть";
        Start = "Начать заново";
    }
}
