// ===================================
// SPLASH SCREEN
// ===================================

// Hide splash screen after animation completes
window.addEventListener('load', () => {
    const splashScreen = document.getElementById('splashScreen');

    // Remove splash screen after 3.3 seconds (animation duration + fade out)
    setTimeout(() => {
        splashScreen.classList.add('hidden');
    }, 3300);
});

// ===================================
// AUTHENTICATION & SECURITY
// ===================================

const ADMIN_PASSWORD = 'admin123'; // Default password
const SESSION_TIMEOUT = 15 * 60 * 1000; // 15 minutes in milliseconds
const MAX_LOGIN_ATTEMPTS = 5;
const LOCKOUT_DURATION = 5 * 60 * 1000; // 5 minutes lockout

let lastActivityTime = Date.now();
let activityCheckInterval = null;

function checkAdminAuth() {
    const isLoggedIn = sessionStorage.getItem('adminLoggedIn') === 'true';
    const loginTime = parseInt(sessionStorage.getItem('adminLoginTime') || '0');
    const currentTime = Date.now();

    // Check if session has expired
    if (isLoggedIn && (currentTime - loginTime > SESSION_TIMEOUT)) {
        logoutAdmin('Session Anda telah berakhir. Silakan login kembali.');
        return false;
    }

    return isLoggedIn;
}

function setAdminAuth(isLoggedIn) {
    if (isLoggedIn) {
        sessionStorage.setItem('adminLoggedIn', 'true');
        sessionStorage.setItem('adminLoginTime', Date.now().toString());
        lastActivityTime = Date.now();
        startActivityMonitoring();
    } else {
        sessionStorage.removeItem('adminLoggedIn');
        sessionStorage.removeItem('adminLoginTime');
        stopActivityMonitoring();
    }
}

function updateLastActivity() {
    lastActivityTime = Date.now();
    // Update login time to extend session
    if (checkAdminAuth()) {
        sessionStorage.setItem('adminLoginTime', Date.now().toString());
    }
}

function startActivityMonitoring() {
    // Clear any existing interval
    stopActivityMonitoring();

    // Check for inactivity every minute
    activityCheckInterval = setInterval(() => {
        const inactiveTime = Date.now() - lastActivityTime;

        if (inactiveTime > SESSION_TIMEOUT) {
            logoutAdmin('Anda telah logout otomatis karena tidak aktif selama 15 menit.');
        }
    }, 60000); // Check every minute

    // Add activity listeners
    const events = ['mousedown', 'keydown', 'scroll', 'touchstart', 'click'];
    events.forEach(event => {
        document.addEventListener(event, updateLastActivity);
    });
}

function stopActivityMonitoring() {
    if (activityCheckInterval) {
        clearInterval(activityCheckInterval);
        activityCheckInterval = null;
    }

    // Remove activity listeners
    const events = ['mousedown', 'keydown', 'scroll', 'touchstart', 'click'];
    events.forEach(event => {
        document.removeEventListener(event, updateLastActivity);
    });
}

function logoutAdmin(message) {
    setAdminAuth(false);
    switchToCustomer();
    if (message) {
        showToast(message);
    }
}

function getLoginAttempts() {
    const attempts = localStorage.getItem('loginAttempts');
    const lockoutTime = localStorage.getItem('lockoutTime');

    // Check if lockout period has passed
    if (lockoutTime && Date.now() - parseInt(lockoutTime) > LOCKOUT_DURATION) {
        localStorage.removeItem('loginAttempts');
        localStorage.removeItem('lockoutTime');
        return 0;
    }

    return parseInt(attempts || '0');
}

function incrementLoginAttempts() {
    const attempts = getLoginAttempts() + 1;
    localStorage.setItem('loginAttempts', attempts.toString());

    if (attempts >= MAX_LOGIN_ATTEMPTS) {
        localStorage.setItem('lockoutTime', Date.now().toString());
    }

    return attempts;
}

function resetLoginAttempts() {
    localStorage.removeItem('loginAttempts');
    localStorage.removeItem('lockoutTime');
}

function isAccountLocked() {
    const lockoutTime = localStorage.getItem('lockoutTime');
    if (!lockoutTime) return false;

    const timeSinceLockout = Date.now() - parseInt(lockoutTime);
    if (timeSinceLockout > LOCKOUT_DURATION) {
        resetLoginAttempts();
        return false;
    }

    return true;
}

function getRemainingLockoutTime() {
    const lockoutTime = localStorage.getItem('lockoutTime');
    if (!lockoutTime) return 0;

    const elapsed = Date.now() - parseInt(lockoutTime);
    const remaining = LOCKOUT_DURATION - elapsed;

    return Math.max(0, Math.ceil(remaining / 1000)); // Return seconds
}


// ===================================
// DATA MANAGEMENT
// ===================================

// Initialize default menu items
const defaultMenu = [
    { id: 1, name: "Otak-Otak", price: 15000, quantity: 0 },
    { id: 2, name: "Otak-Otak Pedas", price: 18000, quantity: 0 },
    { id: 3, name: "Otak-Otak Keju", price: 20000, quantity: 0 },
    { id: 4, name: "Otak-Otak Jumbo", price: 25000, quantity: 0 }
];

// Get data from localStorage or use defaults
function getMenuItems() {
    const stored = localStorage.getItem('menuItems');
    return stored ? JSON.parse(stored) : defaultMenu;
}

function saveMenuItems(items) {
    localStorage.setItem('menuItems', JSON.stringify(items));
}

function getTransactions() {
    const stored = localStorage.getItem('transactions');
    return stored ? JSON.parse(stored) : [];
}

function saveTransactions(transactions) {
    localStorage.setItem('transactions', JSON.stringify(transactions));
}

// Profile data management
const defaultProfile = {
    companyName: 'Otak-Otak',
    tagline: 'Otak-Otak Segar & Lezat',
    description: 'Menyediakan otak-otak berkualitas dengan berbagai varian rasa. Dibuat dari bahan pilihan dan bumbu rahasia yang lezat.',
    aboutParagraph1: 'Kami adalah UMKM yang berdedikasi untuk menghadirkan otak-otak berkualitas tinggi dengan cita rasa autentik. Setiap produk dibuat dengan penuh perhatian menggunakan bahan-bahan pilihan dan resep turun-temurun yang telah disempurnakan selama bertahun-tahun.',
    aboutParagraph2: 'Komitmen kami adalah memberikan pengalaman kuliner yang tak terlupakan dengan menjaga kualitas, kesegaran, dan cita rasa dalam setiap gigitan.',
    mission: 'Menyediakan produk otak-otak berkualitas premium dengan harga terjangkau, mempertahankan cita rasa tradisional, dan memberikan pelayanan terbaik kepada setiap pelanggan.',
    vision: 'Menjadi brand otak-otak terpercaya dan terdepan di Indonesia, dikenal dengan kualitas produk yang konsisten dan inovasi rasa yang terus berkembang.',
    value1Title: 'Kualitas Terjamin',
    value1Desc: 'Hanya menggunakan bahan baku pilihan terbaik',
    value2Title: 'Higienis & Aman',
    value2Desc: 'Proses produksi yang bersih dan terjaga',
    value3Title: 'Kepuasan Pelanggan',
    value3Desc: 'Pelayanan ramah dan responsif',
    value4Title: 'Inovasi Berkelanjutan',
    value4Desc: 'Terus berinovasi dengan varian rasa baru',
    phone: '082315750980',
    address: 'Jakarta, Indonesia',
    hours: '08:00 - 20:00',
    instagram: '@otakotakumkm'
};

function getProfileData() {
    const stored = localStorage.getItem('profileData');
    if (stored) {
        const profile = JSON.parse(stored);
        // Merge with defaults to ensure all fields exist
        return { ...defaultProfile, ...profile };
    }
    return defaultProfile;
}

function saveProfileData(profile) {
    localStorage.setItem('profileData', JSON.stringify(profile));
}

// ===================================
// UTILITY FUNCTIONS
// ===================================

function formatCurrency(amount) {
    return 'Rp ' + amount.toLocaleString('id-ID');
}

function formatDate(dateString) {
    const date = new Date(dateString);
    const options = { day: 'numeric', month: 'short', year: 'numeric' };
    return date.toLocaleDateString('id-ID', options);
}

function showToast(message) {
    const toast = document.getElementById('toast');
    toast.textContent = message;
    toast.classList.add('show');
    setTimeout(() => {
        toast.classList.remove('show');
    }, 3000);
}

// ===================================
// CUSTOMER PAGE
// ===================================

let menuItems = getMenuItems();

function renderMenuTable() {
    const tbody = document.getElementById('menuTableBody');
    tbody.innerHTML = '';

    menuItems.forEach(item => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${item.name}</td>
            <td>${formatCurrency(item.price)}</td>
            <td>
                <div class="quantity-control">
                    <button class="qty-btn" onclick="decreaseQuantity(${item.id})" ${item.quantity === 0 ? 'disabled' : ''}>−</button>
                    <input type="number" class="qty-input" value="${item.quantity}" readonly>
                    <button class="qty-btn" onclick="increaseQuantity(${item.id})">+</button>
                </div>
            </td>
            <td>${formatCurrency(item.price * item.quantity)}</td>
        `;
        tbody.appendChild(row);
    });
}

function renderMenuCards() {
    const container = document.getElementById('menuCards');
    container.innerHTML = '';

    menuItems.forEach(item => {
        const card = document.createElement('div');
        card.className = 'menu-card';
        card.innerHTML = `
            <div class="menu-card-name">${item.name}</div>
            <div class="menu-card-price">${formatCurrency(item.price)}</div>
            <div class="menu-card-controls">
                <div class="quantity-control">
                    <button class="qty-btn" onclick="decreaseQuantity(${item.id})" ${item.quantity === 0 ? 'disabled' : ''}>−</button>
                    <input type="number" class="qty-input" value="${item.quantity}" readonly>
                    <button class="qty-btn" onclick="increaseQuantity(${item.id})">+</button>
                </div>
                <div class="menu-card-total">${formatCurrency(item.price * item.quantity)}</div>
            </div>
        `;
        container.appendChild(card);
    });
}

function increaseQuantity(id) {
    const item = menuItems.find(i => i.id === id);
    if (item && item.quantity < 99) {
        item.quantity++;
        updateCustomerPage();
    }
}

function decreaseQuantity(id) {
    const item = menuItems.find(i => i.id === id);
    if (item && item.quantity > 0) {
        item.quantity--;
        updateCustomerPage();
    }
}

function calculateGrandTotal() {
    return menuItems.reduce((total, item) => total + (item.price * item.quantity), 0);
}

function updateCustomerPage() {
    renderMenuTable();
    renderMenuCards();

    const grandTotal = calculateGrandTotal();
    document.getElementById('grandTotal').textContent = formatCurrency(grandTotal);

    const payButton = document.getElementById('payButton');
    payButton.disabled = grandTotal === 0;
}

function processPayment() {
    const grandTotal = calculateGrandTotal();

    if (grandTotal === 0) {
        showToast('Silakan pilih menu terlebih dahulu');
        return;
    }

    // Validate customer name
    const customerName = document.getElementById('customerName').value.trim();
    if (!customerName) {
        showToast('Silakan masukkan nama Anda terlebih dahulu');
        document.getElementById('customerName').focus();
        return;
    }

    // Show QRIS modal instead of immediate payment
    showQRISModal(grandTotal);
}

function showQRISModal(amount) {
    const modal = document.getElementById('qrisModal');
    const amountDisplay = document.getElementById('qrisAmount');
    const paymentLink = document.getElementById('danaPaymentLink');

    // Update amount
    amountDisplay.textContent = formatCurrency(amount);

    // Generate DANA payment link
    const danaPhoneNumber = '082315750980';
    const merchantName = 'Otak-Otak UMKM';
    const danaLink = `dana://qr?amount=${amount}&note=Pembayaran ${merchantName}&to=${danaPhoneNumber}`;

    // Set the link
    paymentLink.href = danaLink;

    // Try to generate QR Code if library is available
    if (typeof QRCode !== 'undefined') {
        generateQRCode(amount);
    }

    // Show modal
    modal.classList.add('show');
}

function hideQRISModal() {
    const modal = document.getElementById('qrisModal');
    modal.classList.remove('show');
}

function generateQRCode(amount) {
    const qrisContainer = document.getElementById('qrisCode');
    qrisContainer.innerHTML = '';

    // Create canvas for QR code
    const canvas = document.createElement('canvas');
    qrisContainer.appendChild(canvas);

    // Generate DANA payment link
    // Format: dana://qr?amount=AMOUNT&note=DESCRIPTION&to=PHONE_NUMBER
    const danaPhoneNumber = '082315750980';
    const merchantName = 'Otak-Otak UMKM';
    const qrData = `dana://qr?amount=${amount}&note=Pembayaran ${merchantName}&to=${danaPhoneNumber}`;

    // Generate QR code
    QRCode.toCanvas(canvas, qrData, {
        width: 256,
        margin: 2,
        color: {
            dark: '#000000',
            light: '#ffffff'
        }
    }, function (error) {
        if (error) console.error(error);
    });
}

function confirmQRISPayment() {
    const grandTotal = calculateGrandTotal();
    const customerName = document.getElementById('customerName').value.trim();

    // Get current date and time
    const now = new Date();
    const dateStr = now.toLocaleDateString('id-ID', {
        day: '2-digit',
        month: 'long',
        year: 'numeric'
    });
    const timeStr = now.toLocaleTimeString('id-ID', {
        hour: '2-digit',
        minute: '2-digit'
    });

    // Create detailed order description
    const orderedItems = menuItems
        .filter(item => item.quantity > 0)
        .map(item => `${item.name} (${item.quantity}x)`)
        .join(', ');

    const description = `${customerName} - ${dateStr} pukul ${timeStr} - ${orderedItems}`;

    // Create transaction
    const transaction = {
        id: Date.now(),
        date: now.toISOString(),
        description: description,
        type: 'income',
        amount: grandTotal
    };

    // Save transaction
    const transactions = getTransactions();
    transactions.unshift(transaction);
    saveTransactions(transactions);

    // Reset quantities and customer name
    menuItems.forEach(item => item.quantity = 0);
    document.getElementById('customerName').value = '';
    updateCustomerPage();

    // Hide QRIS modal
    hideQRISModal();

    // Show rating modal instead of immediate toast
    showRatingModal(transaction.id);
}

// ===================================
// ADMIN DASHBOARD
// ===================================

function calculateFinancials() {
    const transactions = getTransactions();

    const totalIncome = transactions
        .filter(t => t.type === 'income')
        .reduce((sum, t) => sum + t.amount, 0);

    const totalExpense = transactions
        .filter(t => t.type === 'expense')
        .reduce((sum, t) => sum + t.amount, 0);

    const totalProfit = totalIncome - totalExpense;

    return { totalIncome, totalExpense, totalProfit };
}

function updateDashboardCards() {
    const { totalIncome, totalExpense, totalProfit } = calculateFinancials();

    document.getElementById('totalIncome').textContent = formatCurrency(totalIncome);
    document.getElementById('totalExpense').textContent = formatCurrency(totalExpense);
    document.getElementById('totalProfit').textContent = formatCurrency(totalProfit);
}

function renderTransactionTable(tableId, limit = null) {
    const tbody = document.getElementById(tableId);
    const transactions = getTransactions();
    const displayTransactions = limit ? transactions.slice(0, limit) : transactions;

    if (displayTransactions.length === 0) {
        tbody.innerHTML = '<tr><td colspan="5" class="empty-state">Belum ada transaksi</td></tr>';
        return;
    }

    tbody.innerHTML = '';
    displayTransactions.forEach(transaction => {
        const row = document.createElement('tr');
        const badgeClass = transaction.type === 'income' ? 'badge-income' : 'badge-expense';
        const amountClass = transaction.type === 'income' ? 'amount-income' : 'amount-expense';
        const typeText = transaction.type === 'income' ? 'Pemasukan' : 'Pengeluaran';

        // Add delete button for all transactions
        const deleteTitle = transaction.type === 'income' ? 'Hapus Pemasukan' : 'Hapus Pengeluaran';
        const actionButton = `<button class="btn-delete" onclick="deleteTransaction(${transaction.id})" title="${deleteTitle}">🗑️ Hapus</button>`;

        row.innerHTML = `
            <td>${formatDate(transaction.date)}</td>
            <td>${transaction.description}</td>
            <td><span class="transaction-badge ${badgeClass}">${typeText}</span></td>
            <td class="${amountClass}">${formatCurrency(transaction.amount)}</td>
            <td>${actionButton}</td>
        `;
        tbody.appendChild(row);
    });
}

function updateAdminDashboard() {
    updateDashboardCards();
    renderTransactionTable('dashboardTransactionTable', 10);
    renderTransactionTable('allTransactionTable');
}

// ===================================
// EXPENSE FORM
// ===================================

function handleExpenseSubmit(e) {
    e.preventDefault();

    const description = document.getElementById('expenseDescription').value;
    const amount = parseFloat(document.getElementById('expenseAmount').value);
    const date = document.getElementById('expenseDate').value;

    if (!description || !amount || !date) {
        showToast('Semua field harus diisi');
        return;
    }

    if (amount <= 0) {
        showToast('Nominal harus lebih dari 0');
        return;
    }

    // Create expense transaction
    const transaction = {
        id: Date.now(),
        date: new Date(date).toISOString(),
        description: description,
        type: 'expense',
        amount: amount
    };

    // Save transaction
    const transactions = getTransactions();
    transactions.unshift(transaction);
    saveTransactions(transactions);

    // Reset form
    document.getElementById('expenseForm').reset();
    document.getElementById('expenseDate').valueAsDate = new Date();

    // Update dashboard
    updateAdminDashboard();

    showToast('Pengeluaran berhasil disimpan');
}

// ===================================
// MENU MANAGEMENT
// ===================================

let editingMenuId = null;

function renderMenuEditTable() {
    const tbody = document.getElementById('menuEditTable');
    tbody.innerHTML = '';

    menuItems.forEach(item => {
        const row = document.createElement('tr');

        if (editingMenuId === item.id) {
            row.innerHTML = `
                <td>
                    <input type="text" class="edit-input" id="editName${item.id}" value="${item.name}" placeholder="Nama Menu" required>
                </td>
                <td>
                    <input type="number" class="edit-input" id="editPrice${item.id}" value="${item.price}" min="0" placeholder="Harga" required>
                </td>
                <td>
                    <button class="btn-secondary" onclick="saveMenuEdit(${item.id})">Simpan</button>
                    <button class="btn-cancel" onclick="cancelEdit()">Batal</button>
                </td>
            `;
        } else {
            row.innerHTML = `
                <td>${item.name}</td>
                <td>${formatCurrency(item.price)}</td>
                <td>
                    <button class="btn-secondary" onclick="editMenuPrice(${item.id})">Edit</button>
                    <button class="btn-delete" onclick="deleteMenu(${item.id})" title="Hapus Menu">🗑️ Hapus</button>
                </td>
            `;
        }

        tbody.appendChild(row);
    });
}

function editMenuPrice(id) {
    editingMenuId = id;
    renderMenuEditTable();
}

function saveMenuEdit(id) {
    const newName = document.getElementById(`editName${id}`).value.trim();
    const newPrice = parseFloat(document.getElementById(`editPrice${id}`).value);

    // Validate name
    if (!newName) {
        showToast('Nama menu tidak boleh kosong');
        return;
    }

    // Validate price
    if (!newPrice || newPrice <= 0) {
        showToast('Harga harus lebih dari 0');
        return;
    }

    // Check for duplicate name (excluding current item)
    const duplicateName = menuItems.find(i => i.id !== id && i.name.toLowerCase() === newName.toLowerCase());
    if (duplicateName) {
        showToast('Nama menu sudah ada. Gunakan nama yang berbeda.');
        return;
    }

    const item = menuItems.find(i => i.id === id);
    if (item) {
        const oldName = item.name;
        item.name = newName;
        item.price = newPrice;
        saveMenuItems(menuItems);
        editingMenuId = null;
        renderMenuEditTable();
        updateCustomerPage();

        if (oldName !== newName) {
            showToast(`Menu "${oldName}" berhasil diubah menjadi "${newName}"`);
        } else {
            showToast('Menu berhasil diperbarui');
        }
    }
}

function cancelEdit() {
    editingMenuId = null;
    renderMenuEditTable();
}

function deleteMenu(id) {
    // Find the menu item to delete
    const menuItem = menuItems.find(i => i.id === id);

    if (!menuItem) {
        showToast('Menu tidak ditemukan');
        return;
    }

    // Confirm deletion
    if (!confirm(`Apakah Anda yakin ingin menghapus menu "${menuItem.name}"? Tindakan ini tidak dapat dibatalkan.`)) {
        return;
    }

    // Check if there's only one menu item left
    if (menuItems.length <= 1) {
        showToast('Tidak dapat menghapus menu terakhir. Minimal harus ada 1 menu.');
        return;
    }

    // Remove the menu item
    menuItems = menuItems.filter(i => i.id !== id);

    // Save to localStorage
    saveMenuItems(menuItems);

    // Update all views
    renderMenuEditTable();
    updateCustomerPage();

    showToast(`Menu "${menuItem.name}" berhasil dihapus`);
}

function handleAddMenu(e) {
    e.preventDefault();

    const name = document.getElementById('newMenuName').value.trim();
    const price = parseInt(document.getElementById('newMenuPrice').value);

    // Validation
    if (!name) {
        showToast('Nama menu harus diisi');
        return;
    }

    if (!price || price <= 0) {
        showToast('Harga harus lebih dari 0');
        return;
    }

    // Check if menu name already exists
    if (menuItems.some(item => item.name.toLowerCase() === name.toLowerCase())) {
        showToast('Menu dengan nama ini sudah ada');
        return;
    }

    // Generate new ID
    const newId = menuItems.length > 0 ? Math.max(...menuItems.map(i => i.id)) + 1 : 1;

    // Create new menu item
    const newMenuItem = {
        id: newId,
        name: name,
        price: price
    };

    // Add to menu items
    menuItems.push(newMenuItem);

    // Save to localStorage
    saveMenuItems(menuItems);

    // Update all views
    renderMenuEditTable();
    updateCustomerPage();

    // Clear form
    document.getElementById('newMenuName').value = '';
    document.getElementById('newMenuPrice').value = '';

    // Focus back to name input
    document.getElementById('newMenuName').focus();

    showToast(`Menu "${name}" berhasil ditambahkan`);
}

// ===================================
// TRANSACTION MANAGEMENT
// ===================================

function deleteTransaction(id) {
    // Get current transactions
    const transactions = getTransactions();

    // Find the transaction to delete
    const transactionToDelete = transactions.find(t => t.id === id);

    if (!transactionToDelete) {
        showToast('Transaksi tidak ditemukan');
        return;
    }

    // Set confirmation message based on transaction type
    const transactionType = transactionToDelete.type === 'income' ? 'pemasukan' : 'pengeluaran';
    const confirmMessage = `Apakah Anda yakin ingin menghapus ${transactionType} ini? Tindakan ini tidak dapat dibatalkan.`;

    // Confirm deletion
    if (!confirm(confirmMessage)) {
        return;
    }

    // Remove the transaction
    const updatedTransactions = transactions.filter(t => t.id !== id);
    saveTransactions(updatedTransactions);

    // Update the dashboard
    updateAdminDashboard();

    // Show success message
    const successMessage = transactionType.charAt(0).toUpperCase() + transactionType.slice(1) + ' berhasil dihapus';
    showToast(successMessage);
}

// ===================================
// PROFILE PAGE MANAGEMENT
// ===================================

let profilePreviousPage = 'customer'; // Track where user came from

function showProfilePage() {
    profilePreviousPage = 'customer';
    document.getElementById('customerPage').classList.remove('active');
    document.getElementById('profilePage').classList.add('active');
    updateProfileDisplay();
}

function hideProfilePage() {
    document.getElementById('profilePage').classList.remove('active');
    document.getElementById('customerPage').classList.add('active');
}

function backFromProfile() {
    document.getElementById('profilePage').classList.remove('active');

    if (profilePreviousPage === 'admin') {
        document.getElementById('adminPage').classList.add('active');
    } else {
        document.getElementById('customerPage').classList.add('active');
    }
}

function updateProfileDisplay() {
    const profile = getProfileData();

    // Hero section
    document.getElementById('profileCompanyName').textContent = profile.companyName;
    document.getElementById('profileTagline').textContent = profile.tagline;
    document.getElementById('profileDescription').textContent = profile.description;

    // About section
    const aboutTexts = document.querySelectorAll('.about-text');
    if (aboutTexts.length >= 2) {
        aboutTexts[0].textContent = profile.aboutParagraph1;
        aboutTexts[1].textContent = profile.aboutParagraph2;
    }

    // Mission & Vision
    const mvDescriptions = document.querySelectorAll('.mv-description');
    if (mvDescriptions.length >= 2) {
        mvDescriptions[0].textContent = profile.mission;
        mvDescriptions[1].textContent = profile.vision;
    }

    // Company Values
    const valueTitles = document.querySelectorAll('.value-title');
    const valueDescs = document.querySelectorAll('.value-description');
    if (valueTitles.length >= 4 && valueDescs.length >= 4) {
        valueTitles[0].textContent = profile.value1Title;
        valueDescs[0].textContent = profile.value1Desc;
        valueTitles[1].textContent = profile.value2Title;
        valueDescs[1].textContent = profile.value2Desc;
        valueTitles[2].textContent = profile.value3Title;
        valueDescs[2].textContent = profile.value3Desc;
        valueTitles[3].textContent = profile.value4Title;
        valueDescs[3].textContent = profile.value4Desc;
    }

    // Contact information
    document.getElementById('profilePhone').textContent = profile.phone;
    document.getElementById('profileAddress').textContent = profile.address;
    document.getElementById('profileHours').textContent = profile.hours;
    document.getElementById('profileInstagram').textContent = profile.instagram;
}

// ===================================
// ADMIN PROFILE MANAGEMENT
// ===================================

function loadProfileForm() {
    const profile = getProfileData();

    document.getElementById('companyName').value = profile.companyName;
    document.getElementById('companyTagline').value = profile.tagline;
    document.getElementById('companyDescription').value = profile.description;
    document.getElementById('aboutParagraph1').value = profile.aboutParagraph1;
    document.getElementById('aboutParagraph2').value = profile.aboutParagraph2;
    document.getElementById('companyMission').value = profile.mission;
    document.getElementById('companyVision').value = profile.vision;
    document.getElementById('value1Title').value = profile.value1Title;
    document.getElementById('value1Desc').value = profile.value1Desc;
    document.getElementById('value2Title').value = profile.value2Title;
    document.getElementById('value2Desc').value = profile.value2Desc;
    document.getElementById('value3Title').value = profile.value3Title;
    document.getElementById('value3Desc').value = profile.value3Desc;
    document.getElementById('value4Title').value = profile.value4Title;
    document.getElementById('value4Desc').value = profile.value4Desc;
    document.getElementById('companyPhone').value = profile.phone;
    document.getElementById('companyAddress').value = profile.address;
    document.getElementById('companyHours').value = profile.hours;
    document.getElementById('companyInstagram').value = profile.instagram;
}

function handleProfileSubmit(e) {
    e.preventDefault();

    const profile = {
        companyName: document.getElementById('companyName').value.trim(),
        tagline: document.getElementById('companyTagline').value.trim(),
        description: document.getElementById('companyDescription').value.trim(),
        aboutParagraph1: document.getElementById('aboutParagraph1').value.trim(),
        aboutParagraph2: document.getElementById('aboutParagraph2').value.trim(),
        mission: document.getElementById('companyMission').value.trim(),
        vision: document.getElementById('companyVision').value.trim(),
        value1Title: document.getElementById('value1Title').value.trim(),
        value1Desc: document.getElementById('value1Desc').value.trim(),
        value2Title: document.getElementById('value2Title').value.trim(),
        value2Desc: document.getElementById('value2Desc').value.trim(),
        value3Title: document.getElementById('value3Title').value.trim(),
        value3Desc: document.getElementById('value3Desc').value.trim(),
        value4Title: document.getElementById('value4Title').value.trim(),
        value4Desc: document.getElementById('value4Desc').value.trim(),
        phone: document.getElementById('companyPhone').value.trim(),
        address: document.getElementById('companyAddress').value.trim(),
        hours: document.getElementById('companyHours').value.trim(),
        instagram: document.getElementById('companyInstagram').value.trim()
    };

    // Validate all fields
    const requiredFields = Object.values(profile);
    if (requiredFields.some(field => !field)) {
        showToast('Semua field harus diisi');
        return;
    }

    // Save profile
    saveProfileData(profile);
    updateProfileDisplay();

    showToast('Profil perusahaan berhasil diperbarui');
}

function previewProfile() {
    // Track that we came from admin
    profilePreviousPage = 'admin';
    // Hide admin page
    document.getElementById('adminPage').classList.remove('active');
    // Show profile page
    document.getElementById('profilePage').classList.add('active');
    // Update profile display with latest data
    updateProfileDisplay();
}

// ===================================
// PAGE NAVIGATION
// ===================================

function showLoginModal() {
    const modal = document.getElementById('loginModal');
    modal.classList.add('show');
    document.getElementById('adminPassword').value = '';
    document.getElementById('adminPassword').focus();
}

function hideLoginModal() {
    const modal = document.getElementById('loginModal');
    modal.classList.remove('show');
}

function handleLogin(e) {
    e.preventDefault();

    // Check if account is locked
    if (isAccountLocked()) {
        const remainingTime = getRemainingLockoutTime();
        const minutes = Math.floor(remainingTime / 60);
        const seconds = remainingTime % 60;
        showToast(`Akun terkunci. Coba lagi dalam ${minutes}m ${seconds}s`);
        return;
    }

    const password = document.getElementById('adminPassword').value;

    if (password === ADMIN_PASSWORD) {
        resetLoginAttempts();
        setAdminAuth(true);
        hideLoginModal();
        switchToAdminDashboard();
        showToast('Login berhasil!');
    } else {
        const attempts = incrementLoginAttempts();
        const remaining = MAX_LOGIN_ATTEMPTS - attempts;

        if (attempts >= MAX_LOGIN_ATTEMPTS) {
            showToast('Terlalu banyak percobaan login gagal. Akun terkunci selama 5 menit.');
        } else {
            showToast(`Password salah! Sisa percobaan: ${remaining}`);
        }

        document.getElementById('adminPassword').value = '';
        document.getElementById('adminPassword').focus();
    }
}

function switchToAdmin() {
    if (checkAdminAuth()) {
        switchToAdminDashboard();
    } else {
        showLoginModal();
    }
}

function switchToAdminDashboard() {
    document.getElementById('customerPage').classList.remove('active');
    document.getElementById('adminPage').classList.add('active');
    updateAdminDashboard();
    renderMenuEditTable();
}

function switchToCustomer() {
    // Confirm logout if currently logged in as admin
    if (checkAdminAuth()) {
        if (!confirm('Apakah Anda yakin ingin keluar dari halaman admin?')) {
            return;
        }
        logoutAdmin('Anda telah logout dari admin.');
        return;
    }

    document.getElementById('adminPage').classList.remove('active');
    document.getElementById('customerPage').classList.add('active');
    menuItems = getMenuItems();
    updateCustomerPage();
}

function switchAdminView(viewName) {
    // Update sidebar navigation
    document.querySelectorAll('.nav-item').forEach(item => {
        item.classList.remove('active');
    });
    document.querySelectorAll(`[data-view="${viewName}"]`).forEach(item => {
        item.classList.add('active');
    });

    // Update views
    document.querySelectorAll('.admin-view').forEach(view => {
        view.classList.remove('active');
    });
    document.getElementById(`${viewName}View`).classList.add('active');

    // Update data if needed
    if (viewName === 'dashboard') {
        updateAdminDashboard();
    } else if (viewName === 'transactions') {
        updateAdminDashboard();
    } else if (viewName === 'menu') {
        renderMenuEditTable();
    } else if (viewName === 'profile') {
        loadProfileForm();
    }
}

// ===================================
// EVENT LISTENERS
// ===================================

document.addEventListener('DOMContentLoaded', () => {
    // Initialize customer page
    updateCustomerPage();

    // Set default expense date to today
    const today = new Date().toISOString().split('T')[0];
    document.getElementById('expenseDate').value = today;

    // Page switching
    document.getElementById('switchToAdmin').addEventListener('click', switchToAdmin);
    document.getElementById('switchToCustomer').addEventListener('click', switchToCustomer);

    // Profile page navigation
    document.getElementById('viewProfile').addEventListener('click', showProfilePage);

    // Profile form
    document.getElementById('profileForm').addEventListener('submit', handleProfileSubmit);

    // Payment button
    document.getElementById('payButton').addEventListener('click', processPayment);

    // Expense form
    document.getElementById('expenseForm').addEventListener('submit', handleExpenseSubmit);

    // Add menu form
    document.getElementById('addMenuForm').addEventListener('submit', handleAddMenu);

    // Admin navigation - sidebar
    document.querySelectorAll('.sidebar .nav-item').forEach(item => {
        item.addEventListener('click', (e) => {
            e.preventDefault();
            const viewName = item.getAttribute('data-view');
            switchAdminView(viewName);
        });
    });

    // Login form
    document.getElementById('loginForm').addEventListener('submit', handleLogin);

    // Cancel login
    document.getElementById('cancelLogin').addEventListener('click', () => {
        hideLoginModal();
    });

    // Close modal on outside click
    document.getElementById('loginModal').addEventListener('click', (e) => {
        if (e.target.id === 'loginModal') {
            hideLoginModal();
        }
    });

    // QRIS Payment handlers
    document.getElementById('confirmPayment').addEventListener('click', confirmQRISPayment);

    document.getElementById('cancelPayment').addEventListener('click', () => {
        hideQRISModal();
    });

    // Close QRIS modal on outside click
    document.getElementById('qrisModal').addEventListener('click', (e) => {
        if (e.target.id === 'qrisModal') {
            hideQRISModal();
        }
    });

    // Admin navigation - bottom nav (mobile)
    document.querySelectorAll('.bottom-nav-item').forEach(item => {
        item.addEventListener('click', (e) => {
            e.preventDefault();
            const viewName = item.getAttribute('data-view');
            switchAdminView(viewName);
        });
    });

    // Rating modal event listeners
    initializeRatingModal();
});

// ===================================
// RATING SYSTEM
// ===================================

let currentRating = 0;
let currentTransactionId = null;

function initializeRatingModal() {
    const stars = document.querySelectorAll('.star');
    const ratingText = document.getElementById('ratingText');
    const submitButton = document.getElementById('submitRating');
    const skipButton = document.getElementById('skipRating');

    // Star click handler
    stars.forEach(star => {
        star.addEventListener('click', () => {
            currentRating = parseInt(star.getAttribute('data-rating'));
            updateStarDisplay(currentRating);
            updateRatingText(currentRating);
            submitButton.disabled = false;
        });

        // Hover effect
        star.addEventListener('mouseenter', () => {
            const rating = parseInt(star.getAttribute('data-rating'));
            highlightStars(rating);
        });
    });

    // Reset on mouse leave
    document.getElementById('ratingStars').addEventListener('mouseleave', () => {
        if (currentRating > 0) {
            updateStarDisplay(currentRating);
        } else {
            clearStars();
        }
    });

    // Submit rating
    submitButton.addEventListener('click', submitRating);

    // Skip rating
    skipButton.addEventListener('click', () => {
        hideRatingModal();
        showToast('Terima kasih atas pemesanan Anda!');
    });
}

function showRatingModal(transactionId) {
    currentTransactionId = transactionId;
    currentRating = 0;
    document.getElementById('ratingFeedback').value = '';
    document.getElementById('submitRating').disabled = true;
    clearStars();
    document.getElementById('ratingText').textContent = 'Pilih rating Anda';
    document.getElementById('ratingModal').classList.add('show');
}

function hideRatingModal() {
    document.getElementById('ratingModal').classList.remove('show');
}

function highlightStars(rating) {
    const stars = document.querySelectorAll('.star');
    stars.forEach((star, index) => {
        if (index < rating) {
            star.classList.add('hover');
        } else {
            star.classList.remove('hover');
        }
    });
}

function updateStarDisplay(rating) {
    const stars = document.querySelectorAll('.star');
    stars.forEach((star, index) => {
        star.classList.remove('hover');
        if (index < rating) {
            star.classList.add('selected');
        } else {
            star.classList.remove('selected');
        }
    });
}

function clearStars() {
    const stars = document.querySelectorAll('.star');
    stars.forEach(star => {
        star.classList.remove('selected', 'hover');
    });
}

function updateRatingText(rating) {
    const texts = {
        1: 'Sangat Buruk 😞',
        2: 'Buruk 😕',
        3: 'Cukup 😐',
        4: 'Baik 😊',
        5: 'Sangat Baik! 🤩'
    };
    document.getElementById('ratingText').textContent = texts[rating] || 'Pilih rating Anda';
}

function submitRating() {
    const feedback = document.getElementById('ratingFeedback').value.trim();

    // Save rating
    const rating = {
        id: Date.now(),
        transactionId: currentTransactionId,
        rating: currentRating,
        feedback: feedback,
        date: new Date().toISOString()
    };

    // Get existing ratings
    const ratings = JSON.parse(localStorage.getItem('ratings') || '[]');
    ratings.unshift(rating);
    localStorage.setItem('ratings', JSON.stringify(ratings));

    // Hide modal and show success
    hideRatingModal();
    showToast(`Terima kasih atas rating ${currentRating} bintang! 🌟`);
}

function getRatings() {
    return JSON.parse(localStorage.getItem('ratings') || '[]');
}

function getAverageRating() {
    const ratings = getRatings();
    if (ratings.length === 0) return 0;

    const sum = ratings.reduce((acc, r) => acc + r.rating, 0);
    return (sum / ratings.length).toFixed(1);
}
//Aplikasi Script Sheet
document.getElementById("confirmPayment").addEventListener("click", simpanKeSheet);

function simpanKeSheet() {
    const nama = document.getElementById("customerName").value;
    const total = document.getElementById("grandTotal").innerText;

    // contoh detail pesanan (bisa kamu sesuaikan)
    const detailPesanan = "Pesanan Otak-Otak";

    const data = {
        nama: nama,
        detail: detailPesanan,
        total: total,
        metode: "DANA"
    };

    google.script.run
        .withSuccessHandler(() => {
            alert("Transaksi berhasil disimpan!");
        })
        .simpanTransaksi(data);
}
