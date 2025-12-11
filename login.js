// Lưu nhiều tài khoản
localStorage.setItem("adminUsername", "taikhoan1");
localStorage.setItem("adminPassword", "123");
localStorage.setItem("customerUsername", "customer1");
localStorage.setItem("customerPassword", "123");

// Bắt sự kiện click nút login
document.getElementById("submitBtn").addEventListener("click", function(e){
    e.preventDefault();

    const inputUsername = document.getElementById("username").value;
    const inputPassword = document.getElementById("password").value;

    const adminUsername = localStorage.getItem("adminUsername");
    const adminPassword = localStorage.getItem("adminPassword");
    const customerUsername = localStorage.getItem("customerUsername");
    const customerPassword = localStorage.getItem("customerPassword");

    if(inputUsername === adminUsername && inputPassword === adminPassword){
        alert("Đăng nhập thành công admin!");
        window.location.href = "admin_page.html";
    } else if(inputUsername === customerUsername && inputPassword === customerPassword){
        alert("Đăng nhập thành công customer!");
        window.location.href = "index1.html"; 
    } else {
        alert("Sai tên đăng nhập hoặc mật khẩu!");
    }
});
