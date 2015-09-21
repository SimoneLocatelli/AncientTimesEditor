namespace Editor.Badasquall.Dependencies
{
    /// <summary>
    ///     Represents a Pokemon entity
    /// </summary>
    public interface IPokemon
    {
        /// <summary>
        ///     Gets the attack.
        /// </summary>
        /// <value>
        ///     The attack.
        /// </value>
        int Attack { get; }

        /// <summary>
        ///     Gets the defense.
        /// </summary>
        /// <value>
        ///     The defense.
        /// </value>
        int Defense { get; }

        /// <summary>
        ///     Gets the health points (HP).
        /// </summary>
        /// <value>
        ///     The health points (HP).
        /// </value>
        int HealthPoints { get; }

        /// <summary>
        ///     Gets the individual values (IV statistic).
        /// </summary>
        /// <value>
        ///     The individual values (IV).
        /// </value>
        int IndividualValues { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; }

        /// <summary>
        ///     Gets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        int Number { get; }

        /// <summary>
        ///     Gets the primary type.
        /// </summary>
        /// <value>
        ///     The first type.
        /// </value>
        IPokemonType PrimaryType { get; }

        /// <summary>
        ///     Gets the type of the secondary.
        /// </summary>
        /// <value>
        ///     The type of the secondary.
        /// </value>
        IPokemonType SecondaryType { get; }

        /// <summary>
        ///     Gets the special attack.
        /// </summary>
        /// <value>
        ///     The special attack.
        /// </value>
        int SpecialAttack { get; }

        /// <summary>
        ///     Gets the special defense.
        /// </summary>
        /// <value>
        ///     The special defense.
        /// </value>
        int SpecialDefense { get; }

        /// <summary>
        ///     Gets the speed.
        /// </summary>
        /// <value>
        ///     The speed.
        /// </value>
        int Speed { get; }
    }
}