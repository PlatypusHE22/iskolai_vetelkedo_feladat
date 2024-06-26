# Vetelkedő program
Készítő: Horváth Dávid

## Feladat
### Leírás
Divatja van a különféle tévés vetélkedőknek (A dal, X-faktor és társai). De muszáj mindig tévé előtt ülni?

Szervezzünk meg egy házi dalversenyt! A versenyen bármelyik szak
diákjai indulhatnak, produkciójukat egy zsűri értékeli majd.

A versenyre jelentkező énekeseknek meg kell adniuk a nevüket és a szakjukat, és regisztráláskor mindegyikük kap egy egyedi rajtszámot is. A verseny során egy zsűri tagjai pontozzák őket, minden egyes zsűritag hatására a versenyzők pontszáma a metódus paraméterében megadott értékkel növekszik.

### Elvárások
- Adatok fájlból beolvasása
- Versenyző osztály
- Versenyzők pontozása
- Eredmények megállapítása
- Eredmények csökkenő sorrendbe rendezése
- Eredmények kikeresése szakok alapján

## Program részei
### Adatfájl szerkezete
1. Versenyző neve
2. Versenyző szakja

#### Példa
~~~
Kis Pista
informatikus
Nagy Árpád 
közgazdász
~~~

### Main 
~~~
Versenyző.zsűrikSzáma = 3
versenyzők: Versenyző[]

// Fájl beolvasása és versenyzők létrehozása
file = open_file("versenyzok.txt")
while(file) do
    nev = file.read_line()
    szak = file.read_line()
    versenyzők.add(Versenyző(nev, szak))
end

// Adatok kiírása, majd pontozás
foreach versenyző in versenyzők do
    print(versenyző)
    versenyző.PontotKap()
end

// Csökkenő sorrendbe rendezés
versenyzők.order()
versenyzők.reverse()

// Eredmények kiírása
foreach versenyző in versenyzők do
    print(versenyző)
end

// Eredmények keresése
out "Szeretne eredményeket keresni szakok alapján? ([I]gen, [N]em)"
input választás: Karakter

if választás.lower() == 'i' do
    do
        out "Írja be a keresett szak nevét"
        input szak: String
        talalt: Bool = false
        
        foreach versenyzo in versenyzok do
            if(versenyzo.szak == szak) do
                talalt = true
                out versenyző
            end
        end
        
        if(!talalt) do
            out "Nincs ilyen szakmájú versenyző"
        end
    
        out "Szeretne újra keresni? ([I]gen, [N]em)"
        intput ismétlés: karakter
    while(ismétlés.lower() == 'i')
end


~~~

### Versenyző osztály
~~~
class Versenyző
    static zsűrikSzáma: Egész
    static versenyzőkSzáma: Egész = 0

    rajtszám: Egész
    név: Szöveg
    szak: Szöveg
    pontszám: Egész = 0
    
    constructor Versenyző(név: Szöveg, szak: Szöveg) do
        versenyzőkSzáma++
        this.név = név
        this.szak = szak
        rajtszám = versenyzők száma
    end
    
    function PontotKap()
        for i in zsűrikSzáma do
            pontszám += random_int()
        end
    end
    
    function ToString()
        return <Adatok>
    end
end
~~~