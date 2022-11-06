using C__API.Model;
using C__API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace C__API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _repository.GetUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var usuario = await _repository.GetUsuariosById(id);
            return usuario != null ? Ok(usuario) : NotFound("Usuário não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario) {
            _repository.AddUsuarios(usuario);
            return await _repository.SaveChangesAsync() ? Ok("Usuário Adicionado") : BadRequest("Usuário não Adicionado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Usuario usuario)
        {
            var usuarioExiste = await _repository.GetUsuariosById(id);
            if (usuarioExiste == null) return NotFound("Usuário não encontrado");

            usuarioExiste.nome = usuario.nome ??
            usuarioExiste.nome;
            usuarioExiste.sobrenome = usuario.sobrenome ?? usuarioExiste.sobrenome;
            usuarioExiste.cpf = usuario.cpf ?? usuarioExiste.cpf;
            usuarioExiste.dataNacimento = usuario.dataNacimento != new DateTime() ? usuario.dataNacimento : usuarioExiste.dataNacimento;
            usuarioExiste.telefone = usuario.telefone;
            usuarioExiste.email = usuario.email ?? usuarioExiste.email;
            usuarioExiste.senha = usuario.senha ?? usuarioExiste.senha;

            _repository.AtualizarUsuarios(usuarioExiste);

            return await _repository.SaveChangesAsync() ? Ok("Usuário Atualizado") : BadRequest("Usuário não atualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuariosExiste = await _repository.GetUsuariosById(id);
            if(usuariosExiste == null)
            return NotFound("Usuário não encontrado");

            _repository.DeletarUsuarios(usuariosExiste);

            return await _repository.SaveChangesAsync() ? Ok("Usuário Deletado") : BadRequest("Usuário não Deletado");
        }
    }
}