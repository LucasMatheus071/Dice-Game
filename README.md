# 🎲 Dice Game 2.0 — C# Console Game

## ✔️ Versão atualizada — Sistema de Usuários + Pontuação Persistente

Um minigame em C# onde o jogador precisa ganhar de um número-alvo usando uma rolagem aleatória de dado — agora com sistema de contas e pontuação salva.

---

## 🆕 Novidades da Atualização

Esta versão traz mudanças importantes em relação ao código original:

### ✅ Sistema de Usuários

- Agora o jogo permite cadastrar e reconhecer jogadores.
Cada usuário possui:

- Nome único

- Pontuação própria

- Registro persistente entre execuções

### ✅ Salvamento automático em JSON

Foi criado um arquivo .json que guarda:

* Lista de jogadores

* Pontuação individual

* Histórico persistente

* Ao iniciar o jogo:

- Se o usuário já existir, seus pontos são carregados

- Se for um usuário novo, é criado automaticamente com pontuação 0

---

✅ Nova classe UserDice

Uma nova classe foi adicionada ao projeto para organizar melhor os dados:

```
public class UserDice
    {
        public string DiceNick { get; set; } = "";
        public int Points { get; set; } = 0;
    
        public UserDice() { }
    
        public UserDice(string nickname)
        {
            DiceNick = nickname;
            Console.WriteLine($"Hello {DiceNick}, welcome to DiceGame!");
        }
```
Responsável por:

* Armazenar nome

* Controlar pontos

* Atualizar e retornar o placar

---

## 🎨 Melhorias gerais

### Além das novas features, essa versão traz:

* Organização melhor da lógica do jogo

* Estrutura mais limpa e separada (Program / Pessoa / JSON handling)

* Animações e efeitos visuais mantidos

* Preparação para futuras expansões (menus, dificuldades, ranking, etc.)

* **Novos modos de jogo: Rapid Fire e Random Key** e um novo menu para modos de jogo


## 🚀 Sobre o projeto

O Dice Game continua sendo um jogo simples em C# (Console Application), onde
A cada rodada:

- Um Target entre 1 e 4 é sorteado

- O jogador precisa tirar um número maior para vencer

- O jogo mostra a chance de vitória

- Uma pequena animação é exibida

- A jogada é avaliada

- Os pontos são armazenados para cada jogador

---

## Além disso, nesta versão (v3.0) foram adicionados **dois novos modos de jogo**:

### Modos de jogo atuais:

1. **Rapid Fire**
   - Uma seta se move pela tela
   - O jogador deve pressionar `'E'` **no momento certo** (quando a seta ficar azul)
   - Acertar aumenta os pontos, errar diminui
   - Permite treinar reflexos e timing

2. **Random Key**
   - Uma letra aleatória é sorteada a cada rodada
   - O jogador deve pressionar a **letra correta no timing certo**
   - Similar ao Rapid Fire, mas adiciona variação com letras
   - Pontos são contabilizados de forma semelhante

---

## preview

<img width="220" height="200" alt="image" src="https://github.com/user-attachments/assets/4ef7a336-efb9-44ad-9667-9fb6cce6ade4" />
<img width="220" height="200" alt="image" src="https://github.com/user-attachments/assets/4bd08ef8-a592-4e81-bf6a-702ddb617ef6" />
<img width="220" height="200" alt="image" src="https://github.com/user-attachments/assets/bcf28b0f-0669-4657-a351-f9032daae662" />
<img width="220" height="200" alt="image" src="https://github.com/user-attachments/assets/76e9d0c6-9d46-4c85-b4e3-e675891f8e69" />

---

<img width="213" height="120" alt="image" src="https://github.com/user-attachments/assets/d6bdec56-73ab-423e-b72d-df9719bf105e" />
<img width="172" height="120" alt="image" src="https://github.com/user-attachments/assets/bcd1e584-651b-4f02-b648-ac511df9f1d1" />
<img width="138" height="120" alt="image" src="https://github.com/user-attachments/assets/c88f5953-f72a-4712-b5b7-eefc26a099a4" />
<img width="172" height="120" alt="image" src="https://github.com/user-attachments/assets/4242e41f-6b53-4bed-a84f-2a1e808d46e6" />


---

## Este projeto tem foco em:

* Manipulação de arquivos JSON

* Organização em classes

* Menus e fluxo de jogo estruturado

* Animações no console

* Estrutura de loops de jogo e estados

* Praticar POO 

---

## 🛠 Tecnologias utilizadas

- C# .NET

- Console Application

- Sistema de arquivos (JSON)

- Random

- Thread.Sleep

- Console.ForegroundColor

- Serialização com System.Text.Json
- 
---

## 📌 Status do projeto

### ⏳ Em desenvolvimento
Além das melhorias já feitas, as próximas etapas incluem:

- Menu principal com opções

- Ranking de jogadores

- Múltiplos modos de jogo

- Escolha de dificuldade

- Animações aprimoradas

- Efeitos sonoros

- Refatoração completa para Program + Services + Models
---

## ▶️ Como executar

Certifique-se de ter o .NET SDK instalado

Clone o repositório:

```git clone https://github.com/LucasMatheus071/Dice-Game.git```


Entre na pasta:

```cd Dice-Game```


Execute:

```dotnet run```

---

## 📄 Licença

Este projeto está sob a licença MIT.
Veja o arquivo LICENSE para mais detalhes.

---

## 👤 Autor

Lucas Matheus Fernandes Souza

GitHub: https://github.com/LucasMatheus071
