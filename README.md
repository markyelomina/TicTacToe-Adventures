# TicTacToeAdventures

**TicTacToeAdventures** is a dynamic C# Windows Forms application that brings an upgraded experience to the classic Tic-Tac-Toe game. Designed with interactive gameplay, player profile customization, game timers, audio feedback, and persistent score tracking, this desktop application offers an engaging experience for single-player and multiplayer matches.

---

## 🚀 Features

- **Multiple Game Modes:**
  - **Single Player:** Test your skills against an integrated AI opponent.
  - **Two Player:** Play locally with a friend on the same machine.
- **Player Customization:** Personalize player names and select custom icons/avatars before launching into matches.
- **Score & State Management:**
  - Real-time score tracking for Player 1, Player 2 / AI, and Draws.
  - Dedicated **ScoreManager** to manage persistent stats and easy score resets.
- **Interactive UI & Timers:**
  - Turn-based timer and overall match timer using built-in Windows Forms timers.
  - Audio feedback and sound effects on moves and win/draw events.
- **Game Controls:** Pause, resume, restart, and reset scores directly from the primary interface or menu systems.

---

## 🛠️ Project Structure

- `Form1.cs`: The core game board interface, handling user input, win-condition checks, and UI rendering.
- `ScoreManager.cs`: Class handling game scoring logic, persistent stat tracking, and score resets.
- `Program.cs`: The application entry point.
- `Properties/`: Application resources (images, icons, sound files) and configuration settings.

---

## 📦 Requirements & Environment

- **Framework:** .NET Framework (or .NET Core / .NET 6+ Windows Desktop SDK depending on build config)
- **IDE:** Visual Studio 2019 / 2022
- **Language:** C#
- **Platform:** Windows Desktop (Windows Forms)

---

## 🔧 Getting Started

1. **Clone or Download:**
   Clone the repository to your local machine:
   ```bash
   git clone https://github.com/your-username/TicTacToeAdventures.git
   ```
2. **Open in Visual Studio:**
   Double-click `TicTacToeAdventures.sln` to open the solution in Visual Studio.
3. **Build & Run:**
   Press `F5` or click **Start** in Visual Studio to compile and launch the game.

---

## 🎮 How to Play

1. Choose your game mode (Single Player vs AI or 2 Player local).
2. Enter player names and choose avatars if prompted.
3. Take turns clicking grid cells to place your symbol ($X$ or $O$).
4. Align 3 matching symbols horizontally, vertically, or diagonally to win the round!