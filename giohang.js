// =========================
// GIỎ HÀNG TRANG MENU
// =========================

const foodCards = document.querySelectorAll('.food-card');
const cartBox = document.querySelector('.cart-box');

// Lấy giỏ hàng từ localStorage (nếu có)
let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];

// Render giỏ hàng
function renderCart() {
  if (cartItems.length === 0) {
    cartBox.innerHTML = `
      <img src="https://i.imgur.com/xxl6sAi.png" class="cart-empty-icon" />
      <p class="cart-empty-text">Giỏ hàng hiện đang trống</p>
    `;
    return;
  }

  let html = '';
  cartItems.forEach((item, index) => {
    html += `
      <div class="cart-item">
        <img src="${item.img}" class="cart-item-img"/>
        <div class="cart-item-info">
          <h4>${item.name}</h4>
          <p>${item.price.toLocaleString('vi-VN')}đ</p>
          <p>Số lượng: ${item.qty}</p>
          <button class="remove-item" data-index="${index}">Xóa</button>
        </div>
      </div>
    `;
  });

  html += `<button class="checkout-btn">Thanh toán</button>`;
  cartBox.innerHTML = html;

  // Xóa món
  document.querySelectorAll(".remove-item").forEach(btn => {
    btn.addEventListener("click", e => {
      let index = e.target.dataset.index;
      cartItems.splice(index, 1);

      localStorage.setItem("cartItems", JSON.stringify(cartItems));
      renderCart();
    });
  });

  // Thanh toán
  document.querySelector(".checkout-btn").addEventListener("click", () => {
    localStorage.setItem("cartItems", JSON.stringify(cartItems));
    window.location.href = "thanhtoan.html";
  });
}

// Bấm chọn món
foodCards.forEach(card => {
  card.addEventListener("click", e => {
    if (e.target.classList.contains("remove-item")) return;

    const name = card.querySelector('h3').textContent;
    const priceText = card.querySelector('.food-price').textContent;
    const price = Number(priceText.replace(/[^\d]/g, ""));  // "45.000đ" → 45000
    const img = card.querySelector('img').src;

    // Kiểm tra món đã có trong giỏ
    let existing = cartItems.find(item => item.name === name);

    if (existing) {
      existing.qty += 1;
    } else {
      cartItems.push({
        name,
        price,
        img,
        qty: 1
      });
    }

    localStorage.setItem("cartItems", JSON.stringify(cartItems));
    renderCart();
  });
});

// Load giỏ hàng lần đầu
renderCart();
