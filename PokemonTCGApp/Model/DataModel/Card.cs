using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokemonTCGApp.Model.DataModel
{
    [BsonIgnoreExtraElements]
    public class Card
    {
        /// <summary>
        /// The Id of card in MongoDB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        /// <summary>
        /// The name of the card.
        /// </summary>
        [BsonElement("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The supertype of the card, such as Pokémon, Energy, or Trainer.
        /// </summary>
        [BsonElement("supertype")] //卡牌種類
        public string? Supertype { get; set; }

        /// <summary>
        /// A list of subtypes, such as Basic, EX, Mega, Rapid Strike, etc.
        /// </summary>
        [BsonElement("subtypes")] //卡牌特殊規則 如GX V Vmax VStar
        public List<string>? Subtypes { get; set; }

        /// <summary>
        /// The rarity of the card, such as "Common" or "Rare Rainbow".
        /// </summary>
        [BsonElement("rarity")]  //卡牌等級
        public string? Rarity { get; set; }

        /// <summary>
        /// 卡片環境
        /// </summary>
        [BsonElement("Enviroment")]
        public string Enviroment { get; set; }

        /// <summary>
        /// The energy types for a card, such as Fire, Water, Grass, etc.
        /// </summary>
        [BsonElement("types")] //屬性
        public List<string>? Types { get; set; }

        /// <summary>
        /// The hit points of the card.
        /// </summary>
        [BsonElement("hp")] //血量
        public int? Hp { get; set; }

        /// <summary>
        /// Which Pokémon this card evolves from.
        /// </summary>
        [BsonElement("evolvesFrom")] //進化自
        public string? EvolvesFrom { get; set; }

        /// <summary>
        /// Which Pokémon this card evolves to. Can be multiple, for example, Eevee.
        /// </summary>
        [BsonElement("evolvesTo")] //進化至
        public List<string>? EvolvesTo { get; set; }

        /// <summary>
        /// Any rules associated with the card. For example, VMAX rules, Mega rules, or various trainer rules.
        /// </summary>
        [BsonElement("trainerEffect")] //訓練家卡效果
        public string? TrainerEffect { get; set; }

        /// <summary>
        /// One or more abilities for a given card. An ability has the following fields.
        /// </summary>
        [BsonElement("abilities")]  //特性
        public List<Ability>? Abilities { get; set; }

        /// <summary>
        /// One or more attacks for a given card. An attack has the following fields.
        /// </summary>
        [BsonElement("attacks")]  //攻擊招式
        public List<Attack>? Attacks { get; set; }

        /// <summary>
        /// One or more weaknesses for a given card. A weakness has the following fields.
        /// </summary>
        [BsonElement("weaknesses")]  //弱點
        public List<Weakness>? Weaknesses { get; set; }

        /// <summary>
        /// One or more resistances for a given card. A resistance has the following fields.
        /// </summary>
        [BsonElement("resistances")]  //抗性
        public List<Resistance>? Resistances { get; set; }

        /// <summary>
        /// One or more resistances for a given card. A resistance has the following fields.
        /// </summary>
        [BsonElement("retreatCost")]  //撤退費用
        public List<string>? RetreatCost { get; set; }

        /// <summary>
        /// The set details embedded into the card. See the set object for more details.
        /// </summary>
        [BsonElement("setId")]  //系列
        public string? SetId { get; set; }

        /// <summary>
        /// The number of the card.
        /// </summary>
        [BsonElement("number")]  //系列中的編號
        public int? Number { get; set; }

        /// <summary>
        /// The flavor text of the card. This is the text that can be found on some Pokémon cards that is usually italicized near the bottom of the card.
        /// </summary>
        [BsonElement("flavorText")]  //介紹
        public string? FlavorText { get; set; }

        /// <summary>
        /// The Image of the card.
        /// </summary>
        [BsonElement("image")]  //圖片
        public byte[]? Image { get; set; }

        [BsonElement("updateAdmin")] //更新的管理員
        public string? UpdateAdmin { get; set; }

        [BsonElement("createtime")] //初次編輯時間
        public DateTime CreateTime { get; set; }

        [BsonElement("updatetime")] //更新編輯時間
        public DateTime UpdateTime { get; set; }

        //public string Imgbase64 { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }

    public class Attack
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Damage { get; set; }
    }

    public class Weakness
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class Resistance
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
