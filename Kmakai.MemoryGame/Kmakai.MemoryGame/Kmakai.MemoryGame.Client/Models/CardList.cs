namespace Kmakai.MemoryGame.Client.Models;

public class CardList
{
    private static List<Card> CardsList = new List<Card>()
    {
        new Card { Image = "images/choji.png", Name = "choji", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/gaara.png", Name = "gaara", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/guy.png", Name = "guy", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/hinata.png", Name = "hinata", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/ino.png", Name = "ino", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/jiraya.png", Name = "jiraya", IsFlipped = false, IsMatched = false },        
        new Card { Image = "images/kakashi.png", Name = "kakashi", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/kiba.png", Name = "kiba", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/kushina.png", Name = "kushina", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/minato.png", Name = "minato", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/naruto.png", Name = "naruto", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/narutoandsasuke.png", Name = "narutoandsasuke", IsFlipped = false, IsMatched = false },        
        new Card { Image = "images/neji.png", Name = "neji", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/obito.png", Name = "obito", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/orochimaru.png", Name = "orochimaru", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/rocklee.png", Name = "rocklee", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/sakura.png", Name = "sakura", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/sasuke.png", Name = "sasuke", IsFlipped = false, IsMatched = false },        
        new Card { Image = "images/shino.png", Name = "shino", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/kankuro.png", Name = "kankuro", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/shikamaru.png", Name = "shikamaru", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/temari.png", Name = "temari", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/tenten.png", Name = "tenten", IsFlipped = false, IsMatched = false },
        new Card { Image = "images/tsunade.png", Name = "tsunade", IsFlipped = false, IsMatched = false },


    };

    public static List<Card> GetCards()
    {
        return CardsList.ToList();
    }

    public static List<Card> GetRandomCards(int n)
    {
        return CardsList.OrderBy(x => Guid.NewGuid()).Take(n).ToList();
    }


}
