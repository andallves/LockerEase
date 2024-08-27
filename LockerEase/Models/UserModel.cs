namespace LockerEase.Models;

public class UsuarioModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool isActive { get; set; }
}