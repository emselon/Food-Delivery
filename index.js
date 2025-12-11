
  const btn = document.getElementById("btnMore");
  const more = document.getElementById("more");

  btn.onclick = function () {
    if (more.style.display === "none") {
      more.style.display = "grid";  // nếu bạn đang dùng grid
      btn.textContent = "Thu gọn";
    } else {
      more.style.display = "none";
      btn.textContent = "Xem thêm";
    }
  };

