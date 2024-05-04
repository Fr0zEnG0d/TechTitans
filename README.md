<h1 align="center">Space Invaders - Unity (MVC)</h1>

<h3 align="center">Versão Unity: 2022.3.21f1
  <a href="https://download.unity3d.com/download_unity/bf09ca542b87/UnityDownloadAssistant-2022.3.21f1.exe" style="display: inline-block;">
    <img width="30" height="30" src="https://cdn-icons-png.freepik.com/512/9138/9138599.png" alt="Download">
  </a>
</h3>



<p align="center">
  <a href="https://github.com/Fr0zEnG0d/TechTitans/">
    <img src="https://seeklogo.com/images/S/space-invaders-logo-153AB2CD24-seeklogo.com.png">
    </a>
</p>

## Top-level overview
### Models

*   Classes C# (nativa)

### Views

*   Monobehaviours
*   Recebe input
*   Lê model
*   Comunicação com o controller

### Controller

*   Classes C# (nativa)
*   Altera model
*   Notifica views

* * *
## Brief overview
### Entidades

*   EntityView (classe base da nave - todos os inimigos e o player são filhos dessa classe)
    *   Player
    *   Invader
    *   MysteryShip (nave vermelha) \*
    *   Projectile
    *   Pillbox \*

### Interfaces

*   IDamageReceiver

### Managers - sistemas que controlam o jogo

*   GameFlow
*   AIManager
*   UI

\* Implementar se tivermos tempo

* * *
## In-depth overview
*   **Entity base**
    *   Model
        *   Vector2 Position
        *   Bool IsAlive = true
    *   View
        *   Implementa IDamageReceived
            *   Propaga notificação de dano para o controller;
        *   Update (acontece todo frame)
            *   Before update (coleta os inputs que serão convertidos em comandos);
            *   Envia comandos de input ao controller;
            *   Update transform (componente Unity) baseado no model;
            *   Destroi entidade se IsAlive for false.
    *   Controller
        *   Recebe comando de input
        *   Muda model Vector2 Position
        *   Shoot
        *   Processa notificação de dano sofrido

*   **Player** - Filho de Entity
    *   Model (deriva de EntityMode)
        *   Lives
    *   View (Deriva de EntityView)
        *   BeforeUpdate (acontece todo frame)
            *   Lê input do user

*   **Invader** - Filho de Entity
    *   View
        *   Recebe comando de input da IA Manager

*   **Enum ShipCommand**
    *   MoveLeft
    *   MoveRight
    *   MoveDown
    *   Shoot

*   **Gameflow** (controla o fluxo do jogo)
    *   Model
        *   GameState
            *   MainMenu
            *   Playing
            *   Paused
            *   WinScreen
            *   LoseScreen
    *   View
        *   UI
            *   Escuta os eventos de input dos botões da UI
            *   Envia notificações ao controller
    *   Controller
        *   Altera estado
            *   Muda model
        *   Inicializa o jogo
        *   Verifica condição win
        *   Verifica condição lose
        *   Processa notificações da UI a partir da view

*   **AIManager**
    *   Model
        *   Invader grid
    *   Controller
        *   Envia commando de input para os invaders
        *   Verifica se os invaders podem se mover para baixo
        *   Seleciona um invader para atirar
    *   No view

*   **Projectile**
    *   Model
        *   Vector2 Position
    *   View
        *   Update transform baseado no model;
    *   Controller
        *   Update model
        *   Detecção de colisão
            *   Notifica dano tomado.

* * *

## Space Invaders - version 0.0.1 features:

*   _A nave muda de posição ao apertar as teclas A ou D_

*   _Dispara evento toda vez que o player toma dano_

*   _Interface gráfica de vidas que atualiza quando o player perder uma vida_

*   _Lógica da perda de perda de vidas ainda não foi implementada_

*   _Interface gráfica de Score_
