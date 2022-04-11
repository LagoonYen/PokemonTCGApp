﻿namespace PokemonTCGApp.Model.DTOModel
{
    public class EnumViewModel
    {
        public int Value { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
    }

    public class SupertypesEnumViewModel : EnumViewModel
    {
    }

    public class SubtypesEnumViewModel : EnumViewModel
    {
    }

    public class RaritiesEnumViewModel : EnumViewModel
    {
    }

    public class TypesEnumViewModel : EnumViewModel
    {
    }






}