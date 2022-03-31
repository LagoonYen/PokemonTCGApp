﻿using PokemonTCGApp.Model.DataModel;

namespace PokemonTCGApp.Service
{
    public interface ICardService
    {
        List<Card> GetCards();
        Card GetCard(string id);
        Card CreateCard(Card card);
        void UpdateCard(string id, Card card);
        void DeleteCard(string id);
    }
}
