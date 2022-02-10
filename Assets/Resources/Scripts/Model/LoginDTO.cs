using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginDTO 
{
    public string _nome;
    public string _email;

    public string Email { get => _email; set => _email = value; }
    public string Nome { get => _nome; set => _nome = value; }

    public LoginDTO(string nome, string email)
    {
        Nome = nome;
        Email = email;
      
    }
}
