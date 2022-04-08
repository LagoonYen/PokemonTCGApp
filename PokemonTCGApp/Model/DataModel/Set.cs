﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokemonTCGApp.Model.DataModel
{
    [BsonIgnoreExtraElements]
    public class Set
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// The name of the set.
        /// </summary>
        [BsonElement("name")] //副標題 星星誕生
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The series the set belongs to, like Sword and Shield or Base.
        /// </summary>
        [BsonElement("series")] //主標題 劍 & 盾 / 預組
        public string Series { get; set; } = String.Empty;

        /// <summary>
        /// Any images associated with the set, such as symbol and logo. This is a hash with the following fields:
        /// </summary>
        [BsonElement("image")]  //圖片
        public String? Image { get; set; }

        [BsonElement("releasetime")]  //上市時間
        public DateTime ReleaseTime { get; set; }

        [BsonElement("createtime")] //初次編輯時間
        public DateTime CreateTime { get; set; }

        [BsonElement("updatetime")] //更新編輯時間
        public DateTime UpdateTime { get; set; }
    }
}