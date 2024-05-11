# IF3210-2024-Unity-HAI
## Deskripsi
**Survival Shooter The Sequel** adalah pengembangan lanjut dari **tutorial Unity Survival Shooter** yang diberikan Agate. Fitur-fitur tambahan mencakup story mode, main menu, load and save game, shopkeeper, weapon, pet, orb power up, dan cheat.

Pada aplikasi ini terdapat beberapa spesifikasi sebagai berikut:
1. Main menu memiliki beberapa pilihan:
	- New Game (memulai story mode yang baru)
	- Load Game (melanjutkan game yang sudah pernah disimpan)
	- Statistics : melihat playtime, shot accuracy, story progress, enemies killed, death count, dan distance travel.
	- Settings: mengisi nama, mengatur volume sfx/music, dan difficulty
	- Exit: keluar dari game
2. Terdapat cutscene berupa dialog di awal, tengah, dan akhir story mode. Untuk menyelesaikan game, pemain harus menyelesaikan quest dengan mengalahkan sejumlah musuh yang ditentukan.
3. Terdapat 4 jenis musuh, yaitu Keroco, Kepala Keroco, Jenderal, dan Raja (final boss). Setiap monster yang dikalahkan memiliki reward coin masing-masing.
4. Pemain dapat mengalahkan monster dengan bergerak menggunakan `W`, `A`, `S`, dan `D` dan menyerang dengan menggunakan *left click* ke arah yang dituju. 
5. Setiap menyelesaikan quest, pemain diberi kesempatan untuk menyimpan game ke 3 slot yang tersedia dan dapat menginput nama save game.
6. Setiap menyelesaikan quest, akan muncul `shopkeeper` selama 90 detik. Pemain dapat menekan `e` untuk membuka UI Shop dan membeli pet. Bila pemain menekan `e` ketika tidak ada `shopkeeper` atau `shopkeeper` terlalu jauh, akan ada pesan error.
7. Pemain dapat berganti senjata dengan *scrolling mouse*. Terdapat 3 jenis senjata sebagai berikut:
	- Burstgun
	- Shotgun
	- Sword   
8.  Dalam game ini terdapat 3 jenis pet sebagai berikut:
	- Tipe healer: `Spiky`
	- Tipe attacker: `Shroomie`
	- Tipe enemy buff: `Eagle`

    Pemain hanya bisa memiliki satu pet pada satu waktu. Setiap pet memiliki health dan dapat diserang musuh. Ketika pet mati, pemain baru dapat membeli pet baru. Terdapat 2 jenis Pet yang dapat dibeli, yaitu tipe healer dan attacker, sedangkan tipe enemy buff hanya bisa dimiliki oleh musuh.
9.  Dalam game ini terdapat 3 jenis orb power up berikut yang akan dijatuhkan oleh musuh secara random ketika musuh mati:
	- Orb Increase Damage: meningkatkan damage pemain sebesar 10 persen
	- Orb Restore Health: mengisi ulang health pemain sebesar 20 persen
	- Orb Increase Speed: meningkatkan speed pemain sebesar 20 persen selama 15 detik
10. Ketika pemain kehabisan *health*, pemain diberi kesempatan untuk mengulangi quest yang sedang dijalankan dengan menekan `space`. Akan ada *countdown* yang ditampilkan untuk memberi waktu jika ingin mengulangi, apabila melebihi batas waktu maka permainan selesai dan akan dialihkan ke main menu
11. Terdapat beberapa cheat yang dapat diaktifkan dengan menekan `enter` dan diikuti command kemudian menekan `enter` lagi. Berikut merupakan list command cheat:
	- `kill`: 1 serangan pemain langsung membunuh musuh
	- `god`: HP dari pemain tidak akan berkurang
	- `rich`: pemain mendapat uang tak terhingga
	- `fast`: kecepatan pemain bertambah 2 kali lipat
	- `opat`: HP pet tidak akan berkurang
    - `xpat`: membunuh pet secara instan
    - `orbs`: orbs power up akan langsung muncul di depan pemain
    - `next`: pemain dapat melewati level yang sedang dimainkan
  


## Library

Unity Scripting API:

- UnityEngine
  - UnityEngine.AI
  - UnityEngine.UI
  - UnityEngine.Audio
  - UnityEngine.Events
  - UnityEngine.SceneManagement
  - UnityEngine.Playables
  - UnityEngine.Video
- System
  - System.Collections
    - System.Collections.Generic
  - System.IO
  - System.Linq
- TMPro

## Screenshot 
| Fitur | Screenshot |
|-------|------------|
| Main Menu | ![Main Menu](Screenshot/MainMenu.jpg) |
| Load Game | ![Load Game](Screenshot/Load.jpg)|
| Save Game|![Save1](Screenshot/Save1.jpg) ![Save2](Screenshot/Save2.jpg) |
| Statistics | ![Scoreboard](Screenshot/Statistics.jpg) |
| Settings | ![Settings](Screenshot/Settings.jpg) |
| Gameplay and Quest |![Gameplay1](Screenshot/Quest1.jpg) ![Gameplay2](Screenshot/Quest2.jpg)![Gameplay3](Screenshot/Quest3.jpg) ![Gameplay4](Screenshot/Quest4.jpg)|
| Game Over | ![Game Over1](Screenshot/GameOver1.jpg) ![Game Over2](Screenshot/GameOver2.jpg)|
| Pause Game | ![Pause Game](Screenshot/Pause.jpg) |
| Shopkeeper | ![Shopkeeper](Screenshot/Shopkeeper.jpg) |
| Shop | ![Shop](Screenshot/Shop.jpg) |
| CutScene | ![CutScene](Screenshot/CutScene.jpg) |


## Anggota Kelompok
<table>
  <tr>
    <th>NIM</th>
    <th>Nama</th>
    <th>Tugas</th>
    <th>Durasi Persiapan dan pengerjaan</th>
  </tr>
  <tr>
    <td>13521011</td>
    <td>Afnan Edsa Ramadhan</td>
    <td>
     - Story Mode<br>
     - Shopkeeper<br>
     - Mobs<br>
     - Cheat
    </td>
    <td>40 jam</td>
  </tr>
  <tr>
    <td>13521013</td>
    <td>Eunice Sarah Siregar</td>
    <td>
      - Mobs<br>
      - Pet
    </td>
    <td>40 jam</td>
  </tr>
  <tr>
    <td>13521014</td>
    <td>M. Syauqi Jannatan</td>
    <td>
      - Story Mode<br>
      - Pet<br>
      - Orb Power Up
    </td>
    <td>40 jam</td>
  </tr>
  <tr>
    <td>13521018</td>
    <td>Syarifa Dwi Purnamasari</td>
    <td>
      - Main Menu<br>
      - Weapon
    </td>
    <td>40 jam</td>
  </tr>
  <tr>
    <td>13521025</td>
    <td>M. Haidar Akita Tresnadi </td>
    <td>
      - Story Mode<br>
      - Save and Load Game<br>
      - Statistik Game<br>
      - Game Over
    </td>
    <td>40 jam</td>
  </tr>
</table>
