import 'dart:convert';
import 'dart:developer';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class APIService{
  static String? username;
  static String? password;
  String? route;

  APIService({this.route});

  //void SetParameters(String Username, String Password)
  //{
  //  username=Username;
  //  password=Password;
  //}

  static Future<List<dynamic>?> Get(String route) async{
    //String baseUrl="http://127.0.0.1:5001/api/"+route;
    String baseUrl="http://10.0.2.2:5000/api/"+route;
    //String baseUrl="http://10.0x.17.61:55891/api/"+route;
    //final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      //,headers: {HttpHeaders.authorizationHeader:basicAuth}
    );
    print('Status code-> '+response.statusCode.toString());
    if(response.statusCode==200){
      return json.decode(response.body) as List;
    }
    return null;
  }
}