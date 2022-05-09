import 'package:flutter/material.dart';
import 'package:restoran_seminarski/models/Korisnik.dart';
import 'package:restoran_seminarski/services/APIService.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

Korisnik? result;

Future<void> GetData() async {
  result = await APIService.prijava();
}

class _LoginState extends State<Login> {
  var usernameController = new TextEditingController();
  var passwordController = new TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Padding(
          padding: EdgeInsets.all(20),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              const SizedBox(
                height: 100,
                width: 100,
                child: FittedBox(child: Icon(Icons.local_restaurant)),
              ),
              const SizedBox(height: 65),
              TextField(
                  controller: usernameController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(20)),
                      hintText: 'Korisnicko ime')),
              SizedBox(
                height: 20,
              ),
              TextField(
                  obscureText: true,
                  controller: passwordController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(20)),
                      hintText: 'Password')),
              SizedBox(
                height: 20,
              ),
              Container(
                height: 50,
                width: 250,
                decoration: BoxDecoration(
                    color: Colors.red, borderRadius: BorderRadius.circular(20)),
                child: TextButton(
                  onPressed: () async {
                    APIService.username = usernameController.text;
                    APIService.password = passwordController.text;
                    await GetData();
                    if (result != null) {
                      print(result);
                      APIService.korisnikId = result!.KorisnikId;
                      Navigator.of(context).pushReplacementNamed('Home');
                    }
                  },
                  child: Text('Login',
                      style: TextStyle(color: Colors.white, fontSize: 20)),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
