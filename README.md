# 🎓 Student Management Web API - Final Exam Project

> ✅ Bài kiểm tra cuối kỳ | 🔧 Ngôn ngữ: C# | 📦 Framework: ASP.NET Core Web API

---

## 🧑‍🏫 Mô tả

Ứng dụng Web API quản lý thông tin sinh viên và lớp môn học. Sử dụng kiến trúc **RESTful**, tổ chức theo **service layer**, tích hợp **Swagger UI** để thử nghiệm API.

---

## 🗂️ Các chức năng chính

### 👨‍🎓 Quản lý sinh viên

| Hành động         | Mô tả                                                       |
|------------------|-------------------------------------------------------------|
| `POST /students` | Thêm sinh viên mới                                          |
| `PUT /students/{id}` | Cập nhật sinh viên theo `Id`                           |
| `GET /students/{id}` | Lấy thông tin chi tiết sinh viên theo `Id`             |
| `GET /students`  | Lấy danh sách tất cả sinh viên                              |
| `DELETE /students/{id}` | Xóa sinh viên theo `Id`                              |

> **Thông tin sinh viên**:
> - `Id` (int)
> - `FullName` (string, tối đa 50 ký tự)
> - `StudentCode` (string)
> - `BirthDate` (DateOnly - chỉ ngày)

---

### 🏫 Quản lý lớp môn học

| Hành động         | Mô tả                                                       |
|------------------|-------------------------------------------------------------|
| `POST /classes`  | Thêm lớp môn học mới                                        |
| `PUT /classes/{id}` | Cập nhật thông tin lớp môn học theo `Id`               |
| `GET /classes/{id}` | Lấy thông tin chi tiết lớp môn học theo `Id`           |
| `GET /classes`   | Lấy danh sách tất cả lớp môn học                            |
| `DELETE /classes/{id}` | Xóa lớp môn học theo `Id` (kèm xóa sinh viên trong lớp) |

> **Thông tin lớp học**:
> - `Id` (int)
> - `ClassName` (string, tối đa 50 ký tự)
> - `ClassCode` (string, tối thiểu 5 ký tự)
> - `MaxStudents` (int, > 0)

---

### 🔁 Quan hệ Sinh viên - Lớp học

| Hành động         | Mô tả                                                       |
|------------------|-------------------------------------------------------------|
| `POST /classes/{classId}/students` | Thêm danh sách sinh viên vào lớp (List<int>) |
| `GET /classes/{classId}/students` | Lấy danh sách sinh viên trong lớp (LINQ Join) |

> **Thông tin quan hệ**:
> - `Id` (int)
> - `StudentId` (int)
> - `ClassId` (int)

---

## 🧪 Ràng buộc dữ liệu

Áp dụng trong các lớp `DTO`:

- `[Required]`: bắt buộc nhập
- `[StringLength(50)]`: giới hạn độ dài tên
- `[MinLength(5)]`: ràng buộc mã lớp
- `[Range(1, int.MaxValue)]`: số lượng sinh viên tối đa phải > 0
- `[MinLength(1)]`: danh sách sinh viên khi thêm vào lớp không được rỗng

---

## ⚙️ Kỹ thuật sử dụng

- ASP.NET Core Web API
- Swagger UI
- RESTful API Design
- LINQ (with Join)
- Service Layer
- DTO & Validation
- Xử lý lỗi bằng `try-catch`
- Quản lý dữ liệu bằng `List<T>`

---

## 🚀 Cách chạy project

```bash
git clone https://github.com/your-username/student-api-project.git
cd student-api-project
dotnet run
