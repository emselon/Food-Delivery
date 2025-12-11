// =========================
// TRANG THANH TOÁN
// =========================

const leftDiv = document.querySelector(".left");
const summaryDiv = document.querySelector(".summary");

// Lấy giỏ hàng từ localStorage
let cartItems = JSON.parse(localStorage.getItem("cartItems")) || [];

function formatPrice(num) {
  return num.toLocaleString("vi-VN") + "đ";
}

function renderOrder() {
  if (cartItems.length === 0) {
    leftDiv.innerHTML += "<p>Giỏ hàng trống</p>";
    return;
  }

  let orderHtml = `<h2>Đơn hàng (${cartItems.length})</h2>`;
  let subtotal = 0;

  cartItems.forEach((item) => {
    const itemTotal = item.price * item.qty;
    subtotal += itemTotal;

    orderHtml += `
      <div class="order-item">
        <img src="${item.img}">
        <div class="order-item-info">
          <p>${item.name}</p>
          <span>${item.qty}x</span>
        </div>
        <span>${formatPrice(itemTotal)}</span>
      </div>
    `;
  });

  leftDiv.innerHTML += orderHtml;

  const fee = 20000;
  const total = subtotal + fee;

  summaryDiv.innerHTML = `
    <p><span>Tạm tính (${cartItems.length} phần)</span> <span>${formatPrice(
    subtotal
  )}</span></p>
    <p><span>Phí áp dụng</span> <span>${formatPrice(fee)}</span></p>
    <p style="font-weight:bold;"><span>Tổng số tiền</span> <span>${formatPrice(
      total
    )}</span></p>
    <button class="btn-order">Đặt món</button>
  `;
}

renderOrder();
