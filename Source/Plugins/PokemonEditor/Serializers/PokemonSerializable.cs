using Editor.Badasquall.Dependencies;
using Editor.PokemonEditor.Entities;
using Editor.WpfCommonLibrary.Dependencies;
using System;
using System.Xml.Serialization;

namespace Editor.PokemonEditor.Serializers
{
    /// <summary>
    /// The serializable Pokemon entity 
    /// </summary>
    public class PokemonSerializable : BaseViewModel, IPokemon
    {
        private int attack;

        private int defense;

        private int healthPoints;

        private int individualValues;

        private string name;

        private int number;

        private IPokemonType primaryType;

        private PokemonType primaryTypeSerializable;

        private IPokemonType secondaryType;

        private PokemonType secondaryTypeSerializable;

        private int specialAttack;

        private int specialDefense;

        private int speed;

        /// <summary>
        /// Gets the attack. 
        /// </summary>
        /// <value> The attack. </value>
        public int Attack
        {
            get { return attack; }
            set { SetProperty(ref attack, value); }
        }

        /// <summary>
        /// Gets the defense. 
        /// </summary>
        /// <value> The defense. </value>
        public int Defense
        {
            get { return defense; }
            set { SetProperty(ref defense, value); }
        }

        /// <summary>
        /// Gets the health points (HP). 
        /// </summary>
        /// <value> The health points (HP). </value>
        public int HealthPoints
        {
            get { return healthPoints; }
            set { SetProperty(ref healthPoints, value); }
        }

        /// <summary>
        /// Gets the individual values (IV statistic). 
        /// </summary>
        /// <value> The individual values (IV). </value>
        public int IndividualValues
        {
            get { return individualValues; }
            set { SetProperty(ref individualValues, value); }
        }

        /// <summary>
        /// Gets the name. 
        /// </summary>
        /// <value> The name. </value>
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        /// <summary>
        /// Gets the number. 
        /// </summary>
        /// <value> The number. </value>
        public int Number
        {
            get { return number; }
            set { SetProperty(ref number, value); }
        }

        /// <summary>
        /// Gets the main type of the Pokémon. 
        /// </summary>
        /// <value> The first type. </value>
        [XmlIgnore]
        public IPokemonType PrimaryType
        {
            get { return primaryType; }
            set { SetProperty(ref primaryType, value); }
        }

        /// <summary>
        /// Gets the main type of the Pokémon (serializable). 
        /// </summary>
        /// <value> The first type. </value>
        public PokemonType PrimaryTypeSerializable
        {
            get { return primaryTypeSerializable; }
            set { SetProperty(ref primaryTypeSerializable, value); }
        }

        /// <summary>
        /// Gets the secondary type of the Pokémon. 
        /// </summary>
        /// <value> The type of the secondary. </value>
        [XmlIgnore]
        public IPokemonType SecondaryType
        {
            get { return secondaryType; }
            set { SetProperty(ref secondaryType, value); }
        }

        /// <summary>
        /// Gets the secondary type of the Pokémon. 
        /// </summary>
        /// <value> The type of the secondary. </value>
        public PokemonType SecondaryTypeSerializable
        {
            get { return secondaryTypeSerializable; }
            set { SetProperty(ref secondaryTypeSerializable, value); }
        }

        /// <summary>
        /// Gets the special attack. 
        /// </summary>
        /// <value> The special attack. </value>
        public int SpecialAttack
        {
            get { return specialAttack; }
            set { SetProperty(ref specialAttack, value); }
        }

        /// <summary>
        /// Gets the special defense. 
        /// </summary>
        /// <value> The special defense. </value>
        public int SpecialDefense
        {
            get { return specialDefense; }
            set { SetProperty(ref specialDefense, value); }
        }

        /// <summary>
        /// Gets the speed. 
        /// </summary>
        /// <value> The speed. </value>
        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        /// <summary>
        /// PokemonSerializable contructor 
        /// </summary>
        /// <param name="pokemon"> The IPokemon element to be converted </param>
        public PokemonSerializable(IPokemon pokemon)
        {
            if (pokemon == null)
                throw new ArgumentNullException("pokemon");

            Name = pokemon.Name;
            Number = pokemon.Number;
            HealthPoints = pokemon.HealthPoints;
            IndividualValues = pokemon.IndividualValues;
            Attack = pokemon.Attack;
            Defense = pokemon.Defense;
            PrimaryTypeSerializable = (PokemonType)pokemon.PrimaryType;
            SecondaryTypeSerializable = (PokemonType)pokemon.SecondaryType;
            SpecialAttack = pokemon.SpecialAttack;
            SpecialDefense = pokemon.SpecialDefense;
            Speed = pokemon.Speed;
        }

        /// <summary>
        /// PokemonSerializable contructor 
        /// </summary>
        public PokemonSerializable()
        {
        }
    }
}