# 3D Survival Game - Unity

Dự án trò chơi sinh tồn 3D (3D Survival Game) xây dựng trên nền tảng Unity 3D, thuộc học phần Thực hành Phát triển Ứng dụng Game Nâng cao.

## 🌟 Tính năng chính (Features)
- **Hệ thống điều khiển người chơi (First Person Controller)**:
  - Di chuyển, nhìn xung quanh bằng chuột, kiểm tra mặt đất, nhảy.
- **Hệ thống tương tác & nhặt đồ (Selection & Interaction System)**:
  - Dò tìm tâm ngắm (Raycast), hiển thị tên vật phẩm (`interaction_info_UI`).
  - Nhặt các tài nguyên sinh tồn như Que củi (`Stick`), Viên đá (`Stone`).
- **Hệ thống Túi đồ (Inventory System)**:
  - Bấm phím `I` để mở/đóng túi đồ 15 ô.
  - Hỗ trợ kéo & thả (Drag and Drop) vật phẩm giữa các ô.
- **Hệ thống Chế tạo (Crafting System)**:
  - Bấm phím `C` để mở giao diện chế tạo.
  - Chế tạo Rìu đá (`Axe`) từ 3 Que củi (`Stick`) + 3 Viên đá (`Stone`).
  - Tự động trừ nguyên liệu và cập nhật danh sách đồ dùng tức thì.
- **Đồ họa & Môi trường tùy biến (Visual Polish)**:
  - Bầu trời hoàng hôn rực rỡ (`FS013_Sunset`).
  - Mặt đất cỏ rêu tự nhiên (`Grass_Moss_TerrainLayer`), ánh sáng vàng ấm và sương mù khí quyển.
  - Bố cục làng mạc thời Trung cổ với cối xay gió, tháp canh, nhà gỗ, đàn thỏ sinh động.
  - Giao diện túi đồ và chế tạo bọc viền mạ đồng / gỗ phong cách Fantasy RPG cổ điển.

## 🛠 Công nghệ sử dụng
- **Engine**: Unity 6 (6000.3.7f1)
- **Ngôn ngữ**: C# (.NET / Roslyn)
- **Hệ thống Render**: Built-in Render Pipeline
