import 'dart:convert';

class Korisnik {
  final int KorisnikId;
  final String Ime;
  final String Prezime;
  final String KorisnickoIme;

  Korisnik({
    required this.KorisnikId,
    required this.Ime,
    required this.Prezime,
    required this.KorisnickoIme,
  });

  factory Korisnik.fromJson(Map<String, dynamic> json) {
    return Korisnik(
      KorisnikId: json["id"],
      Ime: json['ime'],
      Prezime: json['prezime'],
      KorisnickoIme: json['korisnickoIme'],
    );
  }

  Map<String, dynamic> toJson() => {
        "Id": KorisnikId,
        "Ime": Ime,
        "Prezime": Prezime,
        "KorisnickoIme": KorisnickoIme,
      };
}
