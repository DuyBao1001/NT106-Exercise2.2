# NT106-Exercise2.2
Thiết kế ứng dụng quản lí người dùng với tính năng đăng nhập/ đăng kí
**-Mô tả bài tập :**
  -Ứng dụng quản lý người dùng với tính năng đăng nhập và đăng kí dựa trên Windows Forms C# và SQL Server
    +Tạo ứng dụng Windows Forms (C#).
    +Có giao diện đăng nhập và đăng ký người dùng.
    +Lưu thông tin người dùng vào cơ sở dữ liệu SQL Server.
    +Mã hóa mật khẩu để tăng tính bảo mật.
**-Hướng dẫn cài đặt:**
  1.Tạo project Windows Forms trong Visual Studio.
  2.Tạo cơ sở dữ liệu và bảng Users trong SQL Server.
  3.Viết code C# để xử lý đăng nhập, đăng ký.
  4.Mã hóa mật khẩu trước khi lưu và khi kiểm tra đăng nhập.
  5.Chạy thử và kiểm tra toàn bộ quy trình.
**-Hướng dẫn sử dụng**
1. Màn hình Đăng nhập
  Khi mở ứng dụng, màn hình đầu tiên hiển thị là Form Đăng nhập.
  Người dùng nhập:
  Tên đăng nhập (Username)
  Mật khẩu (Password) (được ẩn ký tự bằng dấu *)
  Bấm nút Đăng nhập:
  Nếu tài khoản đúng → chuyển sang Màn hình chính.
  Nếu sai → hiện thông báo lỗi.
  Xác nhận không phải là người máy -> Nếu không bắt phải xác nhận
  Nếu chưa có tài khoản, người dùng chọn Đăng ký để chuyển sang Form Đăng ký.
3. Màn hình Đăng ký
  Người dùng nhập thông tin cần thiết:
  Tên đăng nhập (Username)
  Mật khẩu (Password)
  Xác nhận mật khẩu (Confirm Password)
  Email
  Bấm nút Đăng ký:
  Ứng dụng kiểm tra dữ liệu nhập vào:
  Mật khẩu và xác nhận phải trùng khớp.
  Email phải đúng định dạng.
  Xác nhận không phải là người máy
  Xác nhận đồng ý điều khoản
  Username chưa tồn tại trong hệ thống.
  Nếu hợp lệ → hệ thống mã hóa mật khẩu và lưu thông tin vào CSDL.
  Hiện thông báo Đăng ký thành công và trở lại màn hình Đăng nhập.
  Nếu dữ liệu không hợp lệ → hiển thị thông báo lỗi cụ thể.
4. Lưu ý khi sử dụng
  Tên đăng nhập phải duy nhất, không trùng lặp với tài khoản đã có.
  Mật khẩu phải đủ mạnh (có thể kết hợp chữ hoa, chữ thường, số, ký tự đặc biệt).
  Email nhập vào cần đúng định dạng, ví dụ: abc@gmail.com.
  Nếu ứng dụng báo lỗi kết nối, kiểm tra lại SQL Server và chuỗi kết nối trong code.

**Thành viên:**
24520372	Hồ Nhật Duy
24521320	Trần Thuận Phát
24521070	Nguyễn Nhật Minh
24522043	Trần Huy Vũ
24520190	Trương Châu Duy Bảo
