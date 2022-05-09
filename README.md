# eRestoran

## Kredencijali za prijavu

- Administrator

  ```
  Korisnicko ime: admin
  Password: admin
  ```
- Test

  ```
  Korisnicko ime: test
  Password: test
  ```

#### Kredencijali za placanje

  ```
  Broj kartice: 4242 4242 4242 4242
  ```

## Pokretanje aplikacija
1. Kloniranje repozitorija
  ```
  https://github.com/enes-kazazic/eRestoran.git
  ```
2. Otvoriti klonirani repozitorij u konzoli
3. Pokretanje dokerizovanog API-ja i DB-a
  ```
  docker-compose build
  docker-compose up
  ```
4. Otvoriti eRestoran folder
  ```
  cd eRestoran
  ```
5. Otvoriti eRestoran.Mobile folder
  ```
  cd eRestoran.Mobile
  ```
6. Dohvatanje dependecy-a
  ```
  flutter pub get
  ```
7. Pokretanje mobilne aplikacije
  ```
  flutter run
  ```
9. Pokretanje desktop aplikacije
  ```
  1. Otvoriti solution u Visual Studiu
  2. Desni klik na solution
  3. Set Startup Projects
  4. Multiple startup projects
  5. eRestoran.WINUI - Start
  6. OK
  7. CTRL + F5
  ```
