
namespace BrightSky.SharedKernel.Tests
{
    public class OneOfModelingPlayingCards
    {
        [Fact]
        public void OneOf_Suit_Case_Returns_Suit()
        {
            var actual = Suit.Case(new Heart());

            Assert.IsType<Suit>(actual);
        }
        
        [Fact]
        public void OneOf_Suit_ImplicitOperator_Returns_Heart_From_Suit()
        {
            var suit = Suit.Case(new Heart());
            Heart actual = suit;
            
            Assert.IsType<Heart>(actual);
        }
                
        [Fact]
        public void OneOf_Suit_ImplicitOperator_Returns_Suit_From_Heart()
        {
            var heart = new Heart();
            Suit actual = heart;
            
            Assert.IsType<Suit>(actual);
        }

        [Fact]
        public void Use_OneOf_Suit_And_Rank_As_Constructor_Args_For_Card()
        {
            var expected = new Card(new Heart(), new Ace());
            var suit = Suit.Case(new Heart());
            var rank = Rank.Case(new Ace());

            var actual = new Card(suit, rank);
            
            Assert.Equal(expected, actual);
        }

        public record Heart;
        public record Spade;
        public record Diamond;
        public record Club;
        
        public record Suit : OneOf<Heart, Spade, Diamond, Club>
        {
            public new static Suit Case(Heart value) => new(value);
            public new static Suit Case(Spade value) => new(value);
            public new static Suit Case(Diamond value) => new(value);
            public new static Suit Case(Club value) => new(value);

            public static implicit operator Suit(Heart value) => new(value);
            public static implicit operator Suit(Spade value) => new(value);
            public static implicit operator Suit(Diamond value) => new(value);
            public static implicit operator Suit(Club value) => new(value);
            
            public static implicit operator Heart(Suit suit) => suit.Get<Heart>();
            public static implicit operator Spade(Suit suit) => suit.Get<Spade>();
            public static implicit operator Diamond(Suit suit) => suit.Get<Diamond>();
            public static implicit operator Club(Suit suit) => suit.Get<Club>();

            protected Suit(Heart value) : base(value)
            {
            }

            protected Suit(Spade value) : base(value)
            {
            }

            protected Suit(Diamond value) : base(value)
            {
            }

            protected Suit(Club value) : base(value)
            {
            }
        }

        public record Ace; public record Two; public record Three; public record Four; public record Five;
        public record Six; public record Seven; public record Eight; public record Nine; public record Ten;
        public record Jack; public record Queen; public record King;

        public record Rank : OneOf<Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King>
        {
            public new static Rank Case(Ace value) => new(value);
            public new static Rank Case(Two value) => new(value);
            public new static Rank Case(Three value) => new(value);
            public new static Rank Case(Four value) => new(value);
            public new static Rank Case(Five value) => new(value);
            public new static Rank Case(Six value) => new(value);
            public new static Rank Case(Seven value) => new(value);
            public new static Rank Case(Eight value) => new(value);
            public new static Rank Case(Nine value) => new(value);
            public new static Rank Case(Ten value) => new(value);
            public new static Rank Case(Jack value) => new(value);
            public new static Rank Case(Queen value) => new(value);
            public new static Rank Case(King value) => new(value);

            public static implicit operator Rank(Ace value) => new(value);
            public static implicit operator Rank(Two value) => new(value);
            public static implicit operator Rank(Three value) => new(value);
            public static implicit operator Rank(Four value) => new(value);
            public static implicit operator Rank(Five value) => new(value);
            public static implicit operator Rank(Six value) => new(value);
            public static implicit operator Rank(Seven value) => new(value);
            public static implicit operator Rank(Eight value) => new(value);
            public static implicit operator Rank(Nine value) => new(value);
            public static implicit operator Rank(Ten value) => new(value);
            public static implicit operator Rank(Jack value) => new(value);
            public static implicit operator Rank(Queen value) => new(value);
            public static implicit operator Rank(King value) => new(value);

            public static implicit operator Ace(Rank rank) => rank.Get<Ace>();
            public static implicit operator Two(Rank rank) => rank.Get<Two>();
            public static implicit operator Three(Rank rank) => rank.Get<Three>();
            public static implicit operator Four(Rank rank) => rank.Get<Four>();
            public static implicit operator Five(Rank rank) => rank.Get<Five>();
            public static implicit operator Six(Rank rank) => rank.Get<Six>();
            public static implicit operator Seven(Rank rank) => rank.Get<Seven>();
            public static implicit operator Eight(Rank rank) => rank.Get<Eight>();
            public static implicit operator Nine(Rank rank) => rank.Get<Nine>();
            public static implicit operator Ten(Rank rank) => rank.Get<Ten>();
            public static implicit operator Jack(Rank rank) => rank.Get<Jack>();
            public static implicit operator Queen(Rank rank) => rank.Get<Queen>();
            public static implicit operator King(Rank rank) => rank.Get<King>();

            protected Rank(Ace value) : base(value)
            {
            }

            protected Rank(Two value) : base(value)
            {
            }

            protected Rank(Three value) : base(value)
            {
            }

            protected Rank(Four value) : base(value)
            {
            }

            protected Rank(Five value) : base(value)
            {
            }

            protected Rank(Six value) : base(value)
            {
            }

            protected Rank(Seven value) : base(value)
            {
            }

            protected Rank(Eight value) : base(value)
            {
            }

            protected Rank(Nine value) : base(value)
            {
            }

            protected Rank(Ten value) : base(value)
            {
            }

            protected Rank(Jack value) : base(value)
            {
            }

            protected Rank(Queen value) : base(value)
            {
            }

            protected Rank(King value) : base(value)
            {
            }
        }

        public record Card(Suit Suit, Rank Rank);
    }
}
