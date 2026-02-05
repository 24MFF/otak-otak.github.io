/* ===================================
   CSS VARIABLES - DESIGN SYSTEM
   =================================== */
:root {
    /* Modern Primary Colors */
    --primary-dark-blue: #0f172a;
    --primary-blue: #1e40af;
    --primary-blue-light: #3b82f6;
    --primary-dark-green: #065f46;
    --primary-income: #059669;

    /* Gradients */
    --gradient-primary: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    --gradient-income: linear-gradient(135deg, #10b981 0%, #059669 100%);
    --gradient-expense: linear-gradient(135deg, #ef4444 0%, #dc2626 100%);
    --gradient-profit: linear-gradient(135deg, #3b82f6 0%, #1e40af 100%);
    --gradient-dark: linear-gradient(135deg, #1e293b 0%, #0f172a 100%);
    --gradient-light: linear-gradient(135deg, #f8fafc 0%, #e2e8f0 100%);

    /* Secondary Colors */
    --secondary-gray-light: #f8fafc;
    --secondary-gray: #e2e8f0;
    --secondary-gray-dark: #64748b;
    --secondary-expense: #ef4444;

    /* Neutral Colors */
    --white: #ffffff;
    --black: #0f172a;
    --gray-50: #f8fafc;
    --gray-100: #f1f5f9;
    --gray-200: #e2e8f0;
    --gray-300: #cbd5e1;
    --gray-700: #334155;
    --gray-800: #1e293b;
    --gray-900: #0f172a;

    /* Semantic Colors */
    --color-income: #059669;
    --color-expense: #64748b;
    --color-profit: #3b82f6;

    /* Typography */
    --font-size-xs: 12px;
    --font-size-sm: 14px;
    --font-size-base: 16px;
    --font-size-lg: 18px;
    --font-size-xl: 20px;
    --font-size-2xl: 24px;
    --font-size-3xl: 32px;
    --font-size-4xl: 48px;

    --font-weight-normal: 400;
    --font-weight-medium: 500;
    --font-weight-semibold: 600;
    --font-weight-bold: 700;

    /* Spacing */
    --spacing-1: 4px;
    --spacing-2: 8px;
    --spacing-3: 12px;
    --spacing-4: 16px;
    --spacing-5: 20px;
    --spacing-6: 24px;
    --spacing-8: 32px;
    --spacing-10: 40px;
    --spacing-12: 48px;

    /* Shadows */
    --shadow-sm: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
    --shadow-md: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
    --shadow-lg: 0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -2px rgba(0, 0, 0, 0.05);
    --shadow-xl: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04);
    --shadow-2xl: 0 25px 50px -12px rgba(0, 0, 0, 0.25);

    /* Border Radius */
    --radius-sm: 6px;
    --radius-md: 8px;
    --radius-lg: 12px;
    --radius-xl: 16px;
    --radius-2xl: 24px;

    /* Sidebar */
    --sidebar-width: 240px;

    /* Transitions */
    --transition-fast: 150ms cubic-bezier(0.4, 0, 0.2, 1);
    --transition-base: 200ms cubic-bezier(0.4, 0, 0.2, 1);
    --transition-slow: 300ms cubic-bezier(0.4, 0, 0.2, 1);
}

/* ===================================
   RESET & BASE STYLES
   =================================== */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
    font-size: var(--font-size-base);
    color: var(--black);
    background:
        linear-gradient(rgba(255, 248, 240, 0.85), rgba(255, 237, 213, 0.85)),
        url('background.jpg') center/cover fixed;
    line-height: 1.6;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    position: relative;
    overflow-x: hidden;
}

body::before {
    content: '';
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background:
        radial-gradient(circle at 20% 30%, rgba(255, 255, 255, 0.3) 0%, transparent 40%),
        radial-gradient(circle at 80% 70%, rgba(255, 255, 255, 0.2) 0%, transparent 40%);
    z-index: -1;
    pointer-events: none;
    animation: backgroundPulse 15s ease-in-out infinite;
}

@keyframes backgroundPulse {

    0%,
    100% {
        opacity: 1;
    }

    50% {
        opacity: 0.7;
    }
}

/* ===================================
   SPLASH SCREEN
   =================================== */
.splash-screen {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(135deg, #FFD700 0%, #FF8C00 50%, #DAA520 100%);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 9999;
    animation: splashFadeOut 0.8s ease-out 2.5s forwards;
}

.splash-screen.hidden {
    display: none;
}

.splash-content {
    text-align: center;
    animation: splashContentIn 1s ease-out;
}

.splash-title {
    font-size: clamp(48px, 10vw, 96px);
    font-weight: var(--font-weight-bold);
    color: var(--white);
    margin: 0;
    text-shadow: 0 8px 32px rgba(0, 0, 0, 0.3);
    letter-spacing: 0.05em;
    animation: splashTitleScale 1.2s ease-out;
}

.splash-subtitle {
    font-size: clamp(20px, 4vw, 32px);
    font-weight: var(--font-weight-semibold);
    color: rgba(255, 255, 255, 0.95);
    margin-top: var(--spacing-3);
    letter-spacing: 0.2em;
    text-transform: uppercase;
    animation: splashSubtitleFade 1s ease-out 0.3s both;
}

.splash-loader {
    width: 60px;
    height: 4px;
    background: rgba(255, 255, 255, 0.3);
    border-radius: 2px;
    margin: var(--spacing-6) auto 0;
    position: relative;
    overflow: hidden;
    animation: splashLoaderFade 1s ease-out 0.5s both;
}

.splash-loader::after {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: var(--white);
    border-radius: 2px;
    animation: splashLoaderSlide 1.5s ease-in-out infinite;
}

@keyframes splashContentIn {
    from {
        opacity: 0;
        transform: translateY(30px);
    }

    to {
        opacity: 1;
        transform: translateY(0);
    }
}

@keyframes splashTitleScale {
    0% {
        opacity: 0;
        transform: scale(0.5);
    }

    50% {
        transform: scale(1.1);
    }

    100% {
        opacity: 1;
        transform: scale(1);
    }
}

@keyframes splashSubtitleFade {
    from {
        opacity: 0;
        transform: translateY(20px);
    }

    to {
        opacity: 1;
        transform: translateY(0);
    }
}

@keyframes splashLoaderFade {
    from {
        opacity: 0;
    }

    to {
        opacity: 1;
    }
}

@keyframes splashLoaderSlide {
    0% {
        transform: translateX(-100%);
    }

    100% {
        transform: translateX(100%);
    }
}

@keyframes splashFadeOut {
    to {
        opacity: 0;
        visibility: hidden;
    }
}

/* ===================================
   PAGE MANAGEMENT
   =================================== */
.page {
    display: none;
}

.page.active {
    display: block;
}

/* ===================================
   CONTAINER
   =================================== */
.container {
    max-width: 1200px;
    margin: 0 auto;
    padding: var(--spacing-4);
}

@media (min-width: 768px) {
    .container {
        padding: var(--spacing-6);
    }
}

/* ===================================
   CUSTOMER PAGE - HEADER
   =================================== */
.customer-header {
    background: rgba(255, 255, 255, 0.75);
    backdrop-filter: blur(20px) saturate(180%);
    -webkit-backdrop-filter: blur(20px) saturate(180%);
    border-bottom: 1px solid rgba(255, 215, 0, 0.3);
    padding: var(--spacing-4) var(--spacing-6);
    text-align: center;
    position: sticky;
    top: 0;
    z-index: 100;
    display: flex;
    justify-content: space-between;
    align-items: center;
    box-shadow: 0 8px 32px rgba(218, 165, 32, 0.15);
    border-radius: 0 0 20px 20px;
    animation: slideDown 0.6s ease-out;
}

@keyframes slideDown {
    from {
        transform: translateY(-100%);
        opacity: 0;
    }

    to {
        transform: translateY(0);
        opacity: 1;
    }
}

.customer-header h1 {
    font-size: var(--font-size-2xl);
    font-weight: var(--font-weight-bold);
    background: linear-gradient(135deg, #FF8C00 0%, #DAA520 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    flex: 1;
    text-shadow: 0 2px 10px rgba(255, 140, 0, 0.2);
    animation: fadeInScale 0.8s ease-out 0.2s both;
}

.header-spacer {
    width: 80px;
    /* Same width as switch-btn to balance the layout */
}

.profile-btn,
.back-btn {
    min-width: 80px;
}

@keyframes fadeInScale {
    from {
        opacity: 0;
        transform: scale(0.8);
    }

    to {
        opacity: 1;
        transform: scale(1);
    }
}

.switch-btn {
    padding: var(--spacing-2) var(--spacing-4);
    background: var(--gradient-primary);
    color: var(--white);
    border: none;
    border-radius: var(--radius-md);
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-semibold);
    cursor: pointer;
    transition: all var(--transition-base);
    box-shadow: 0 4px 15px rgba(102, 126, 234, 0.4);
    position: relative;
    overflow: hidden;
}

.switch-btn::after {
    content: '';
    position: absolute;
    top: 50%;
    left: 50%;
    width: 0;
    height: 0;
    border-radius: 50%;
    background: rgba(255, 255, 255, 0.3);
    transform: translate(-50%, -50%);
    transition: width 0.6s, height 0.6s;
}

.switch-btn:hover::after {
    width: 300px;
    height: 300px;
}

.switch-btn:hover {
    transform: translateY(-3px) scale(1.05);
    box-shadow: 0 8px 25px rgba(102, 126, 234, 0.5);
}

/* ===================================
   MENU TABLE (DESKTOP)
   =================================== */
.table-container {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border: 2px solid rgba(255, 215, 0, 0.2);
    border-radius: var(--radius-xl);
    overflow: auto;
    margin-bottom: var(--spacing-6);
    box-shadow: 0 10px 40px rgba(218, 165, 32, 0.15);
    transition: all var(--transition-base);
    animation: fadeInUp 0.8s ease-out 0.3s both;
}

@keyframes fadeInUp {
    from {
        opacity: 0;
        transform: translateY(30px);
    }

    to {
        opacity: 1;
        transform: translateY(0);
    }
}

.table-container:hover {
    box-shadow: 0 15px 60px rgba(218, 165, 32, 0.25);
    transform: translateY(-3px);
    border-color: rgba(255, 215, 0, 0.4);
}

.menu-table {
    width: 100%;
    border-collapse: collapse;
}

.menu-table thead {
    background: var(--gray-100);
}

.menu-table th {
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-900);
    padding: var(--spacing-3) var(--spacing-4);
    text-align: left;
    border-bottom: 2px solid var(--gray-200);
}

.menu-table th:nth-child(2),
.menu-table th:nth-child(4) {
    text-align: right;
}

.menu-table th:nth-child(3) {
    text-align: center;
}

.menu-table tbody tr {
    border-bottom: 1px solid var(--gray-200);
    transition: all var(--transition-base);
}

.menu-table tbody tr:last-child {
    border-bottom: none;
}

.menu-table tbody tr:hover {
    background: linear-gradient(90deg, rgba(255, 215, 0, 0.05) 0%, rgba(255, 140, 0, 0.05) 100%);
    transform: scale(1.02);
    box-shadow: 0 4px 12px rgba(218, 165, 32, 0.1);
}

.menu-table td {
    padding: var(--spacing-4);
    font-size: var(--font-size-base);
    color: var(--gray-900);
}

.menu-table td:nth-child(1) {
    font-weight: var(--font-weight-medium);
}

.menu-table td:nth-child(2) {
    color: var(--gray-700);
    text-align: right;
}

.menu-table td:nth-child(3) {
    text-align: center;
}

.menu-table td:nth-child(4) {
    font-weight: var(--font-weight-semibold);
    color: var(--primary-dark-blue);
    text-align: right;
}

/* Hide table on mobile */
@media (max-width: 767px) {
    .menu-table {
        display: none;
    }
}

/* ===================================
   MENU CARDS (MOBILE)
   =================================== */
.menu-cards {
    display: none;
}

@media (max-width: 767px) {
    .menu-cards {
        display: block;
    }
}

.menu-card {
    background: rgba(255, 255, 255, 0.9);
    backdrop-filter: blur(10px);
    border: 2px solid rgba(255, 215, 0, 0.3);
    border-radius: 16px;
    padding: var(--spacing-5);
    margin-bottom: var(--spacing-4);
    box-shadow: 0 8px 24px rgba(218, 165, 32, 0.15);
    transition: all var(--transition-base);
    animation: slideInRight 0.6s ease-out both;
}

.menu-card:nth-child(1) {
    animation-delay: 0.1s;
}

.menu-card:nth-child(2) {
    animation-delay: 0.2s;
}

.menu-card:nth-child(3) {
    animation-delay: 0.3s;
}

.menu-card:nth-child(4) {
    animation-delay: 0.4s;
}

@keyframes slideInRight {
    from {
        opacity: 0;
        transform: translateX(50px);
    }

    to {
        opacity: 1;
        transform: translateX(0);
    }
}

.menu-card:hover {
    transform: translateY(-4px);
    box-shadow: 0 12px 36px rgba(218, 165, 32, 0.25);
    border-color: rgba(255, 215, 0, 0.5);
}

.menu-card-name {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-semibold);
    background: linear-gradient(135deg, #FF8C00 0%, #DAA520 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    margin-bottom: var(--spacing-2);
}

.menu-card-price {
    font-size: var(--font-size-base);
    color: var(--gray-700);
    margin-bottom: var(--spacing-3);
    font-weight: var(--font-weight-medium);
}

.menu-card-controls {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.menu-card-total {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
}

/* ===================================
   QUANTITY CONTROL
   =================================== */
.quantity-control {
    display: flex;
    align-items: center;
    gap: var(--spacing-2);
}

.qty-btn {
    width: 36px;
    height: 36px;
    border: 2px solid rgba(255, 215, 0, 0.4);
    border-radius: 8px;
    background: linear-gradient(135deg, rgba(255, 255, 255, 0.9) 0%, rgba(255, 250, 240, 0.9) 100%);
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    color: #FF8C00;
    cursor: pointer;
    transition: all var(--transition-base);
    display: flex;
    align-items: center;
    justify-content: center;
    box-shadow: 0 2px 8px rgba(218, 165, 32, 0.2);
}

.qty-btn:hover:not(:disabled) {
    background: linear-gradient(135deg, #FFD700 0%, #FFA500 100%);
    border-color: #FF8C00;
    color: white;
    transform: scale(1.1);
    box-shadow: 0 4px 12px rgba(255, 140, 0, 0.4);
}

.qty-btn:disabled {
    opacity: 0.4;
    cursor: not-allowed;
    background: var(--gray-100);
    border-color: var(--gray-200);
}

.qty-input {
    width: 60px;
    height: 36px;
    text-align: center;
    border: 2px solid rgba(255, 215, 0, 0.3);
    border-radius: 8px;
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-bold);
    color: #FF8C00;
    background: rgba(255, 255, 255, 0.8);
}

/* ===================================
   TOTAL DISPLAY
   =================================== */
.total-display {
    background: rgba(255, 255, 255, 0.9);
    backdrop-filter: blur(10px);
    border: 3px solid transparent;
    background-image:
        linear-gradient(rgba(255, 255, 255, 0.9), rgba(255, 255, 255, 0.9)),
        linear-gradient(135deg, #FFD700 0%, #FF8C00 50%, #DAA520 100%);
    background-origin: border-box;
    background-clip: padding-box, border-box;
    border-radius: var(--radius-xl);
    padding: var(--spacing-6);
    margin-bottom: var(--spacing-6);
    text-align: right;
    box-shadow: 0 12px 40px rgba(218, 165, 32, 0.25);
    transition: all var(--transition-base);
    position: relative;
    overflow: hidden;
    animation: fadeInUp 0.8s ease-out 0.5s both;
}

.total-display::before {
    content: '';
    position: absolute;
    top: -50%;
    left: -50%;
    width: 200%;
    height: 200%;
    background: linear-gradient(45deg, transparent, rgba(255, 215, 0, 0.1), transparent);
    animation: shimmer 3s infinite;
}

@keyframes shimmer {
    0% {
        transform: translateX(-100%) translateY(-100%) rotate(45deg);
    }

    100% {
        transform: translateX(100%) translateY(100%) rotate(45deg);
    }
}

.total-display:hover {
    transform: translateY(-4px) scale(1.02);
    box-shadow: 0 16px 60px rgba(218, 165, 32, 0.35);
}

.total-label {
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-medium);
    color: var(--gray-700);
    margin-bottom: var(--spacing-1);
}

.total-amount {
    font-size: var(--font-size-3xl);
    font-weight: var(--font-weight-bold);
    color: var(--primary-dark-blue);
}

@media (min-width: 768px) {
    .total-amount {
        font-size: var(--font-size-4xl);
    }
}

/* ===================================
   CUSTOMER NAME SECTION
   =================================== */
.customer-name-section {
    background: rgba(255, 255, 255, 0.9);
    backdrop-filter: blur(10px);
    border: 2px solid rgba(255, 215, 0, 0.3);
    border-radius: var(--radius-xl);
    padding: var(--spacing-5);
    margin-bottom: var(--spacing-6);
    box-shadow: 0 10px 40px rgba(218, 165, 32, 0.15);
    transition: all var(--transition-base);
    animation: fadeInUp 0.8s ease-out 0.6s both;
}

.customer-name-section:hover {
    box-shadow: 0 15px 60px rgba(218, 165, 32, 0.25);
    transform: translateY(-2px);
}

.customer-name-label {
    display: flex;
    align-items: center;
    gap: var(--spacing-2);
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-semibold);
    background: linear-gradient(135deg, #FF8C00 0%, #DAA520 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    margin-bottom: var(--spacing-3);
}

.name-icon {
    width: 20px;
    height: 20px;
    stroke: #FF8C00;
    flex-shrink: 0;
}

.customer-name-input {
    width: 100%;
    padding: var(--spacing-3) var(--spacing-4);
    border: 2px solid rgba(255, 215, 0, 0.4);
    border-radius: var(--radius-lg);
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-medium);
    font-family: inherit;
    background: rgba(255, 255, 255, 0.8);
    color: var(--gray-900);
    transition: all var(--transition-base);
    box-shadow: 0 2px 8px rgba(218, 165, 32, 0.1);
}

.customer-name-input:focus {
    outline: none;
    border-color: #FF8C00;
    box-shadow: 0 4px 16px rgba(255, 140, 0, 0.3);
    transform: translateY(-1px);
    background: rgba(255, 255, 255, 0.95);
}

.customer-name-input::placeholder {
    color: var(--gray-700);
    opacity: 0.6;
}


/* ===================================
   BUTTONS
   =================================== */
.btn-primary {
    padding: var(--spacing-3) var(--spacing-6);
    background: var(--gradient-primary);
    color: var(--white);
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-semibold);
    border: none;
    border-radius: var(--radius-lg);
    cursor: pointer;
    transition: all var(--transition-base);
    min-height: 48px;
    box-shadow: 0 8px 24px rgba(102, 126, 234, 0.4);
    position: relative;
    overflow: hidden;
}

.btn-primary::before {
    content: '';
    position: absolute;
    top: 0;
    left: -100%;
    width: 100%;
    height: 100%;
    background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.4), transparent);
    transition: left 0.5s;
}

.btn-primary:hover::before {
    left: 100%;
}

.btn-primary::after {
    content: '';
    position: absolute;
    inset: 0;
    border-radius: var(--radius-lg);
    padding: 2px;
    background: linear-gradient(135deg, rgba(255, 255, 255, 0.3), transparent);
    -webkit-mask: linear-gradient(#fff 0 0) content-box, linear-gradient(#fff 0 0);
    -webkit-mask-composite: xor;
    mask: linear-gradient(#fff 0 0) content-box, linear-gradient(#fff 0 0);
    mask-composite: exclude;
    opacity: 0;
    transition: opacity var(--transition-base);
}

.btn-primary:hover::after {
    opacity: 1;
}

.btn-primary:hover:not(:disabled) {
    transform: translateY(-4px) scale(1.03);
    box-shadow: 0 12px 40px rgba(102, 126, 234, 0.5);
}

.btn-primary:active:not(:disabled) {
    transform: translateY(-1px) scale(1);
    box-shadow: 0 6px 20px rgba(102, 126, 234, 0.4);
}

.btn-primary:disabled {
    background: var(--gray-200);
    color: var(--gray-700);
    cursor: not-allowed;
    box-shadow: none;
}

.btn-large {
    width: 100%;
    max-width: 400px;
    height: 56px;
    font-size: var(--font-size-lg);
    display: block;
    margin: 0 auto;
    animation: fadeInUp 0.8s ease-out 0.8s both, pulse 2s ease-in-out 2s infinite;
}

@keyframes pulse {

    0%,
    100% {
        box-shadow: 0 8px 24px rgba(102, 126, 234, 0.4);
    }

    50% {
        box-shadow: 0 12px 32px rgba(102, 126, 234, 0.6);
    }
}

.btn-secondary {
    padding: 6px 16px;
    background: var(--white);
    border: 1px solid var(--primary-dark-blue);
    color: var(--primary-dark-blue);
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-medium);
    border-radius: 6px;
    cursor: pointer;
    transition: all 0.2s;
}

.btn-secondary:hover {
    background: var(--primary-dark-blue);
    color: var(--white);
}

.btn-cancel {
    padding: 6px 12px;
    background: var(--white);
    border: 1px solid var(--gray-200);
    color: var(--gray-700);
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-medium);
    border-radius: 6px;
    cursor: pointer;
    margin-left: var(--spacing-2);
}

.btn-cancel:hover {
    background: var(--gray-50);
}

/* ===================================
   CONTACT SECTION
   =================================== */
.contact-section {
    background: rgba(255, 255, 255, 0.9);
    backdrop-filter: blur(10px);
    border: 2px solid rgba(255, 215, 0, 0.3);
    border-radius: var(--radius-xl);
    padding: var(--spacing-6);
    margin-bottom: var(--spacing-6);
    box-shadow: 0 10px 40px rgba(218, 165, 32, 0.15);
    transition: all var(--transition-base);
    animation: fadeInUp 0.8s ease-out 0.7s both;
}

.contact-section:hover {
    box-shadow: 0 15px 60px rgba(218, 165, 32, 0.25);
    transform: translateY(-2px);
}

.contact-title {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    background: linear-gradient(135deg, #FF8C00 0%, #DAA520 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    text-align: center;
    margin-bottom: var(--spacing-5);
}

.contact-links {
    display: flex;
    flex-direction: column;
    gap: var(--spacing-3);
}

@media (min-width: 768px) {
    .contact-links {
        flex-direction: row;
        justify-content: center;
        gap: var(--spacing-4);
    }
}

.contact-link {
    display: flex;
    align-items: center;
    gap: var(--spacing-2);
    padding: var(--spacing-3) var(--spacing-4);
    border-radius: var(--radius-lg);
    text-decoration: none;
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-semibold);
    transition: all var(--transition-base);
    border: 2px solid;
    background: rgba(255, 255, 255, 0.8);
    backdrop-filter: blur(5px);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    flex: 1;
    justify-content: center;
}

.contact-icon {
    width: 20px;
    height: 20px;
    flex-shrink: 0;
}

.contact-text {
    white-space: nowrap;
}

/* Phone Link */
.phone-link {
    border-color: rgba(34, 197, 94, 0.4);
    color: #16a34a;
}

.phone-link:hover {
    background: linear-gradient(135deg, #22c55e 0%, #16a34a 100%);
    color: white;
    transform: translateY(-3px) scale(1.05);
    box-shadow: 0 8px 20px rgba(34, 197, 94, 0.4);
    border-color: #22c55e;
}

.phone-link:hover .contact-icon {
    stroke: white;
}

/* Instagram Link */
.instagram-link {
    border-color: rgba(225, 48, 108, 0.4);
    color: #e1306c;
}

.instagram-link:hover {
    background: linear-gradient(135deg, #f77737 0%, #e1306c 50%, #c13584 100%);
    color: white;
    transform: translateY(-3px) scale(1.05);
    box-shadow: 0 8px 20px rgba(225, 48, 108, 0.4);
    border-color: #e1306c;
}

.instagram-link:hover .contact-icon {
    stroke: white;
}

/* Facebook Link */
.facebook-link {
    border-color: rgba(24, 119, 242, 0.4);
    color: #1877f2;
}

.facebook-link:hover {
    background: linear-gradient(135deg, #4267B2 0%, #1877f2 100%);
    color: white;
    transform: translateY(-3px) scale(1.05);
    box-shadow: 0 8px 20px rgba(24, 119, 242, 0.4);
    border-color: #1877f2;
}

.facebook-link:hover .contact-icon {
    fill: white;
}

/* Mobile Responsive */
@media (max-width: 767px) {
    .contact-section {
        padding: var(--spacing-4);
    }

    .contact-link {
        font-size: var(--font-size-xs);
        padding: var(--spacing-2) var(--spacing-3);
    }

    .contact-icon {
        width: 18px;
        height: 18px;
    }
}

/* ===================================
   PROFILE PAGE - MODERN SECTIONS
   =================================== */

.profile-container {
    max-width: 1200px;
    margin: 0 auto;
}

/* Hero Section */
.profile-hero {
    background: linear-gradient(135deg, rgba(102, 126, 234, 0.1) 0%, rgba(118, 75, 162, 0.1) 100%);
    border-radius: var(--radius-2xl);
    padding: var(--spacing-12) var(--spacing-6);
    margin-bottom: var(--spacing-8);
    text-align: center;
    position: relative;
    overflow: hidden;
    border: 2px solid rgba(102, 126, 234, 0.2);
    box-shadow: 0 20px 60px rgba(102, 126, 234, 0.15);
    animation: fadeInUp 0.8s ease-out;
}

.profile-hero::before {
    content: '';
    position: absolute;
    top: -50%;
    left: -50%;
    width: 200%;
    height: 200%;
    background: linear-gradient(45deg, transparent, rgba(102, 126, 234, 0.05), transparent);
    animation: shimmer 3s infinite;
}

.hero-content {
    position: relative;
    z-index: 1;
}

.hero-title {
    font-size: clamp(32px, 5vw, 56px);
    font-weight: var(--font-weight-bold);
    background: var(--gradient-primary);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    margin-bottom: var(--spacing-3);
    animation: fadeInScale 0.8s ease-out 0.2s both;
}

.hero-subtitle {
    font-size: clamp(18px, 3vw, 24px);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-700);
    margin-bottom: var(--spacing-4);
    animation: fadeInUp 0.8s ease-out 0.3s both;
}

.hero-description {
    font-size: var(--font-size-lg);
    color: var(--gray-700);
    max-width: 700px;
    margin: 0 auto var(--spacing-6);
    line-height: 1.8;
    animation: fadeInUp 0.8s ease-out 0.4s both;
}

.hero-buttons {
    display: flex;
    gap: var(--spacing-4);
    justify-content: center;
    flex-wrap: wrap;
    animation: fadeInUp 0.8s ease-out 0.5s both;
}

.hero-btn {
    display: inline-flex;
    align-items: center;
    gap: var(--spacing-2);
    padding: var(--spacing-4) var(--spacing-6);
    border-radius: var(--radius-lg);
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-semibold);
    text-decoration: none;
    transition: all var(--transition-base);
    box-shadow: 0 8px 24px rgba(0, 0, 0, 0.15);
    position: relative;
    overflow: hidden;
}

.hero-btn::before {
    content: '';
    position: absolute;
    top: 0;
    left: -100%;
    width: 100%;
    height: 100%;
    background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.3), transparent);
    transition: left 0.5s;
}

.hero-btn:hover::before {
    left: 100%;
}

.hero-btn.primary {
    background: var(--gradient-primary);
    color: var(--white);
}

.hero-btn.primary:hover {
    transform: translateY(-3px) scale(1.05);
    box-shadow: 0 12px 32px rgba(102, 126, 234, 0.4);
}

.hero-btn.secondary {
    background: var(--white);
    color: var(--primary-blue);
    border: 2px solid var(--primary-blue);
}

.hero-btn.secondary:hover {
    background: var(--primary-blue);
    color: var(--white);
    transform: translateY(-3px) scale(1.05);
    box-shadow: 0 12px 32px rgba(30, 64, 175, 0.3);
}

.btn-icon {
    width: 20px;
    height: 20px;
}

/* About Section */
.profile-about {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border-radius: var(--radius-xl);
    padding: var(--spacing-8) var(--spacing-6);
    margin-bottom: var(--spacing-8);
    border: 2px solid rgba(255, 215, 0, 0.2);
    box-shadow: 0 10px 40px rgba(218, 165, 32, 0.15);
    animation: fadeInUp 0.8s ease-out 0.2s both;
}

.about-content {
    max-width: 800px;
    margin: 0 auto;
}

.about-text {
    font-size: var(--font-size-lg);
    line-height: 1.8;
    color: var(--gray-700);
    margin-bottom: var(--spacing-4);
}

.about-text:last-child {
    margin-bottom: 0;
}

/* Mission & Vision */
.profile-mission-vision {
    margin-bottom: var(--spacing-8);
    animation: fadeInUp 0.8s ease-out 0.3s both;
}

.mv-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
    gap: var(--spacing-6);
}

.mv-card {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border-radius: var(--radius-xl);
    padding: var(--spacing-8);
    border: 2px solid;
    box-shadow: 0 10px 40px rgba(0, 0, 0, 0.1);
    transition: all var(--transition-base);
    position: relative;
    overflow: hidden;
}

.mv-card::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    height: 4px;
    background: linear-gradient(90deg, transparent, currentColor, transparent);
    opacity: 0;
    transition: opacity var(--transition-base);
}

.mv-card:hover::before {
    opacity: 1;
}

.mission-card {
    border-color: rgba(16, 185, 129, 0.3);
    color: #10b981;
}

.mission-card:hover {
    transform: translateY(-8px) scale(1.02);
    box-shadow: 0 20px 60px rgba(16, 185, 129, 0.25);
    border-color: #10b981;
}

.vision-card {
    border-color: rgba(59, 130, 246, 0.3);
    color: #3b82f6;
}

.vision-card:hover {
    transform: translateY(-8px) scale(1.02);
    box-shadow: 0 20px 60px rgba(59, 130, 246, 0.25);
    border-color: #3b82f6;
}

.mv-icon {
    width: 64px;
    height: 64px;
    margin: 0 auto var(--spacing-4);
    padding: var(--spacing-4);
    border-radius: var(--radius-xl);
    background: linear-gradient(135deg, rgba(255, 255, 255, 0.9), rgba(255, 255, 255, 0.6));
    display: flex;
    align-items: center;
    justify-content: center;
    box-shadow: 0 4px 16px rgba(0, 0, 0, 0.1);
}

.mv-icon svg {
    width: 100%;
    height: 100%;
    stroke: currentColor;
}

.mv-title {
    font-size: var(--font-size-xl);
    font-weight: var(--font-weight-bold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-3);
    text-align: center;
}

.mv-description {
    font-size: var(--font-size-base);
    line-height: 1.8;
    color: var(--gray-700);
    text-align: center;
}

/* Company Values */
.profile-values {
    margin-bottom: var(--spacing-8);
    animation: fadeInUp 0.8s ease-out 0.4s both;
}

.values-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: var(--spacing-5);
}

.value-card {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border-radius: var(--radius-xl);
    padding: var(--spacing-6);
    border: 2px solid rgba(102, 126, 234, 0.2);
    box-shadow: 0 8px 32px rgba(102, 126, 234, 0.1);
    transition: all var(--transition-base);
    text-align: center;
}

.value-card:hover {
    transform: translateY(-8px);
    box-shadow: 0 16px 48px rgba(102, 126, 234, 0.25);
    border-color: rgba(102, 126, 234, 0.5);
}

.value-icon {
    width: 56px;
    height: 56px;
    margin: 0 auto var(--spacing-4);
    padding: var(--spacing-3);
    border-radius: var(--radius-lg);
    background: var(--gradient-primary);
    display: flex;
    align-items: center;
    justify-content: center;
    box-shadow: 0 8px 24px rgba(102, 126, 234, 0.3);
}

.value-icon svg {
    width: 100%;
    height: 100%;
    stroke: var(--white);
}

.value-title {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-2);
}

.value-description {
    font-size: var(--font-size-sm);
    color: var(--gray-700);
    line-height: 1.6;
}

/* Company Statistics */
.profile-stats {
    background: var(--gradient-primary);
    border-radius: var(--radius-2xl);
    padding: var(--spacing-8) var(--spacing-6);
    margin-bottom: var(--spacing-8);
    box-shadow: 0 20px 60px rgba(102, 126, 234, 0.3);
    animation: fadeInUp 0.8s ease-out 0.5s both;
}

.profile-stats .section-title {
    color: var(--white);
    text-align: center;
    margin-top: 0;
}

.stats-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
    gap: var(--spacing-6);
}

.stat-card {
    background: rgba(255, 255, 255, 0.15);
    backdrop-filter: blur(10px);
    border-radius: var(--radius-xl);
    padding: var(--spacing-6);
    text-align: center;
    border: 2px solid rgba(255, 255, 255, 0.2);
    transition: all var(--transition-base);
}

.stat-card:hover {
    background: rgba(255, 255, 255, 0.25);
    transform: translateY(-8px) scale(1.05);
    box-shadow: 0 16px 48px rgba(0, 0, 0, 0.2);
}

.stat-number {
    font-size: clamp(36px, 5vw, 48px);
    font-weight: var(--font-weight-bold);
    color: var(--white);
    margin-bottom: var(--spacing-2);
    text-shadow: 0 2px 8px rgba(0, 0, 0, 0.2);
}

.stat-label {
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-medium);
    color: rgba(255, 255, 255, 0.9);
}

/* Contact Grid */
.profile-contact {
    margin-bottom: var(--spacing-8);
    animation: fadeInUp 0.8s ease-out 0.6s both;
}

.contact-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: var(--spacing-5);
}

.contact-card {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border-radius: var(--radius-xl);
    padding: var(--spacing-6);
    border: 2px solid rgba(255, 215, 0, 0.2);
    box-shadow: 0 8px 32px rgba(218, 165, 32, 0.15);
    transition: all var(--transition-base);
    text-align: center;
}

.contact-card:hover {
    transform: translateY(-8px);
    box-shadow: 0 16px 48px rgba(218, 165, 32, 0.25);
    border-color: rgba(255, 215, 0, 0.4);
}

.contact-card .contact-icon {
    width: 48px;
    height: 48px;
    margin: 0 auto var(--spacing-4);
    padding: var(--spacing-3);
    border-radius: var(--radius-lg);
    background: linear-gradient(135deg, #FF8C00 0%, #DAA520 100%);
    display: flex;
    align-items: center;
    justify-content: center;
    box-shadow: 0 8px 24px rgba(255, 140, 0, 0.3);
}

.contact-card .contact-icon svg {
    width: 100%;
    height: 100%;
    stroke: var(--white);
}

.contact-card .contact-title {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-2);
    text-align: center;
    background: none;
    -webkit-text-fill-color: initial;
}

.contact-card .contact-value {
    font-size: var(--font-size-base);
    color: var(--gray-700);
    font-weight: var(--font-weight-medium);
}

/* Call to Action */
.profile-cta {
    background: linear-gradient(135deg, rgba(16, 185, 129, 0.1) 0%, rgba(5, 150, 105, 0.1) 100%);
    border-radius: var(--radius-2xl);
    padding: var(--spacing-10) var(--spacing-6);
    text-align: center;
    border: 2px solid rgba(16, 185, 129, 0.3);
    box-shadow: 0 20px 60px rgba(16, 185, 129, 0.15);
    animation: fadeInUp 0.8s ease-out 0.7s both;
}

.cta-content {
    max-width: 600px;
    margin: 0 auto;
}

.cta-title {
    font-size: clamp(28px, 4vw, 40px);
    font-weight: var(--font-weight-bold);
    background: linear-gradient(135deg, #10b981 0%, #059669 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    margin-bottom: var(--spacing-3);
}

.cta-description {
    font-size: var(--font-size-lg);
    color: var(--gray-700);
    margin-bottom: var(--spacing-6);
}

.cta-button {
    display: inline-flex;
    align-items: center;
    gap: var(--spacing-2);
    padding: var(--spacing-4) var(--spacing-8);
    background: linear-gradient(135deg, #10b981 0%, #059669 100%);
    color: var(--white);
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    border: none;
    border-radius: var(--radius-lg);
    cursor: pointer;
    transition: all var(--transition-base);
    box-shadow: 0 8px 24px rgba(16, 185, 129, 0.4);
    position: relative;
    overflow: hidden;
}

.cta-button::before {
    content: '';
    position: absolute;
    top: 0;
    left: -100%;
    width: 100%;
    height: 100%;
    background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.3), transparent);
    transition: left 0.5s;
}

.cta-button:hover::before {
    left: 100%;
}

.cta-button:hover {
    transform: translateY(-4px) scale(1.05);
    box-shadow: 0 16px 40px rgba(16, 185, 129, 0.5);
}

.cta-button:active {
    transform: translateY(-2px) scale(1.02);
}

/* Responsive Adjustments */
@media (max-width: 767px) {
    .profile-hero {
        padding: var(--spacing-8) var(--spacing-4);
    }

    .hero-buttons {
        flex-direction: column;
        align-items: stretch;
    }

    .hero-btn {
        justify-content: center;
    }

    .mv-grid,
    .values-grid,
    .stats-grid,
    .contact-grid {
        grid-template-columns: 1fr;
    }

    .profile-about,
    .profile-stats,
    .profile-cta {
        padding: var(--spacing-6) var(--spacing-4);
    }
}


/* ===================================
   ADMIN PAGE - SIDEBAR
   =================================== */
#adminPage {
    display: none;
}

#adminPage.active {
    display: flex;
    min-height: 100vh;
}

.sidebar {
    width: var(--sidebar-width);
    background: var(--gradient-dark);
    min-height: 100vh;
    padding: var(--spacing-6) 0;
    position: fixed;
    left: 0;
    top: 0;
    box-shadow: var(--shadow-xl);
}

.sidebar-header {
    padding: 0 var(--spacing-6);
    margin-bottom: var(--spacing-6);
}

.sidebar-header h2 {
    font-size: var(--font-size-xl);
    color: var(--white);
}

.sidebar-nav {
    display: flex;
    flex-direction: column;
}

.nav-item {
    display: flex;
    align-items: center;
    gap: var(--spacing-3);
    padding: var(--spacing-3) var(--spacing-6);
    color: var(--gray-200);
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-medium);
    text-decoration: none;
    border-left: 3px solid transparent;
    transition: all var(--transition-base);
    position: relative;
}

.nav-item::before {
    content: '';
    position: absolute;
    left: 0;
    top: 0;
    bottom: 0;
    width: 3px;
    background: var(--gradient-primary);
    opacity: 0;
    transition: opacity var(--transition-base);
}

.nav-item:hover {
    background: rgba(255, 255, 255, 0.05);
    color: var(--white);
}

.nav-item.active {
    background: rgba(255, 255, 255, 0.1);
    color: var(--white);
    border-left-color: transparent;
}

.nav-item.active::before {
    opacity: 1;
}

.nav-icon {
    font-size: var(--font-size-xl);
}

.sidebar-switch {
    margin: var(--spacing-6) var(--spacing-6) 0;
    width: calc(100% - var(--spacing-12));
}

/* Hide sidebar on mobile */
@media (max-width: 1023px) {
    .sidebar {
        display: none;
    }
}

/* ===================================
   ADMIN PAGE - MAIN CONTENT
   =================================== */
.admin-main {
    flex: 1;
    margin-left: var(--sidebar-width);
    padding-bottom: 80px;
}

@media (max-width: 1023px) {
    .admin-main {
        margin-left: 0;
    }
}

.admin-view {
    display: none;
}

.admin-view.active {
    display: block;
}

.page-title {
    font-size: var(--font-size-2xl);
    font-weight: var(--font-weight-bold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-6);
}

.section-title {
    font-size: var(--font-size-xl);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-900);
    margin: var(--spacing-8) 0 var(--spacing-4);
}

/* ===================================
   DASHBOARD CARDS
   =================================== */
.dashboard-cards {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
    gap: var(--spacing-4);
    margin-bottom: var(--spacing-8);
}

.dashboard-card {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border: 2px solid rgba(255, 215, 0, 0.2);
    border-radius: var(--radius-xl);
    padding: var(--spacing-6);
    box-shadow: 0 10px 30px rgba(218, 165, 32, 0.15);
    min-height: 160px;
    transition: all var(--transition-base);
    position: relative;
    overflow: hidden;
}

.dashboard-card::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    height: 5px;
    background: var(--gradient-primary);
    opacity: 0;
    transition: all var(--transition-base);
}

.dashboard-card:hover {
    transform: translateY(-8px) scale(1.02);
    box-shadow: 0 20px 50px rgba(218, 165, 32, 0.3);
    border-color: rgba(255, 215, 0, 0.4);
}

.dashboard-card:hover::before {
    opacity: 1;
    height: 8px;
}

.income-card {
    border-top: 4px solid transparent;
    background-image: linear-gradient(var(--white), var(--white)), var(--gradient-income);
    background-origin: border-box;
    background-clip: padding-box, border-box;
}

.expense-card {
    border-top: 4px solid transparent;
    background-image: linear-gradient(var(--white), var(--white)), var(--gradient-expense);
    background-origin: border-box;
    background-clip: padding-box, border-box;
}

.profit-card {
    border-top: 4px solid transparent;
    background-image: linear-gradient(var(--white), var(--white)), var(--gradient-profit);
    background-origin: border-box;
    background-clip: padding-box, border-box;
}

.card-label {
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-700);
    margin-bottom: var(--spacing-2);
    text-transform: uppercase;
    letter-spacing: 0.5px;
}

.card-value {
    font-size: 36px;
    font-weight: var(--font-weight-bold);
}

@media (min-width: 768px) {
    .card-value {
        font-size: var(--font-size-4xl);
    }
}

.income-card .card-value {
    color: var(--color-income);
}

.expense-card .card-value {
    color: var(--color-expense);
}

.profit-card .card-value {
    color: var(--color-profit);
}

/* ===================================
   TRANSACTION TABLE
   =================================== */
.transaction-table {
    width: 100%;
    border-collapse: collapse;
}

.transaction-table thead {
    background: var(--gray-100);
}

.transaction-table th {
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-900);
    padding: var(--spacing-3) var(--spacing-4);
    text-align: left;
    border-bottom: 2px solid var(--gray-200);
}

.transaction-table th:last-child {
    text-align: right;
}

.transaction-table tbody tr {
    border-bottom: 1px solid var(--gray-200);
}

.transaction-table tbody tr:last-child {
    border-bottom: none;
}

.transaction-table tbody tr:hover {
    background: var(--gray-50);
}

.transaction-table td {
    padding: var(--spacing-3) var(--spacing-4);
    font-size: var(--font-size-sm);
    color: var(--gray-900);
}

.transaction-table td:last-child {
    font-weight: var(--font-weight-semibold);
    text-align: right;
}

.transaction-badge {
    display: inline-block;
    padding: 4px 12px;
    border-radius: 12px;
    font-size: var(--font-size-xs);
    font-weight: var(--font-weight-medium);
}

.badge-income {
    background: rgba(45, 122, 79, 0.1);
    color: var(--color-income);
}

.badge-expense {
    background: rgba(107, 114, 128, 0.1);
    color: var(--color-expense);
}

.amount-income {
    color: var(--color-income);
}

.amount-expense {
    color: var(--color-expense);
}

.empty-state {
    text-align: center;
    padding: var(--spacing-12) var(--spacing-6);
    color: var(--gray-700);
    font-size: var(--font-size-sm);
}

/* Delete button for transactions */
.btn-delete {
    padding: 6px 12px;
    background: linear-gradient(135deg, #ef4444 0%, #dc2626 100%);
    color: var(--white);
    border: none;
    border-radius: 6px;
    font-size: var(--font-size-xs);
    font-weight: var(--font-weight-medium);
    cursor: pointer;
    transition: all var(--transition-base);
    box-shadow: var(--shadow-sm);
    display: inline-flex;
    align-items: center;
    gap: 4px;
}

.btn-delete:hover {
    transform: translateY(-2px);
    box-shadow: var(--shadow-md);
    background: linear-gradient(135deg, #dc2626 0%, #b91c1c 100%);
}

.btn-delete:active {
    transform: translateY(0);
    box-shadow: var(--shadow-sm);
}

.no-action {
    color: var(--gray-300);
    font-size: var(--font-size-sm);
    text-align: center;
    display: block;
}

/* ===================================
   FORMS
   =================================== */
.form-container {
    background: var(--white);
    border: 1px solid var(--gray-200);
    border-radius: 8px;
    padding: var(--spacing-6);
    margin-bottom: var(--spacing-8);
}

.form-title {
    font-size: var(--font-size-xl);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-5);
}

.form-group {
    margin-bottom: var(--spacing-4);
}

.form-group label {
    display: block;
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-medium);
    color: var(--gray-700);
    margin-bottom: 6px;
}

.form-group input {
    width: 100%;
    padding: 10px 12px;
    border: 2px solid var(--gray-200);
    border-radius: var(--radius-md);
    font-size: var(--font-size-base);
    min-height: 44px;
    font-family: inherit;
    transition: all var(--transition-base);
    background: var(--white);
}

.form-group input:focus {
    outline: none;
    border-color: transparent;
    box-shadow: 0 0 0 3px rgba(102, 126, 234, 0.3);
    transform: translateY(-1px);
}

.form-group textarea {
    width: 100%;
    padding: 10px 12px;
    border: 2px solid var(--gray-200);
    border-radius: var(--radius-md);
    font-size: var(--font-size-base);
    font-family: inherit;
    transition: all var(--transition-base);
    background: var(--white);
    resize: vertical;
    min-height: 100px;
}

.form-group textarea:focus {
    outline: none;
    border-color: transparent;
    box-shadow: 0 0 0 3px rgba(102, 126, 234, 0.3);
    transform: translateY(-1px);
}

/* Profile View Header */
.profile-view-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: var(--spacing-6);
    flex-wrap: wrap;
    gap: var(--spacing-4);
}

.btn-preview {
    display: inline-flex;
    align-items: center;
    gap: var(--spacing-2);
    padding: var(--spacing-3) var(--spacing-5);
    background: linear-gradient(135deg, #10b981 0%, #059669 100%);
    color: var(--white);
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-semibold);
    border: none;
    border-radius: var(--radius-lg);
    cursor: pointer;
    transition: all var(--transition-base);
    box-shadow: 0 4px 16px rgba(16, 185, 129, 0.3);
}

.btn-preview:hover {
    transform: translateY(-2px);
    box-shadow: 0 8px 24px rgba(16, 185, 129, 0.4);
}

.btn-preview .btn-icon {
    width: 18px;
    height: 18px;
}

/* Form Section Title */
.form-section-title {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    color: var(--gray-900);
    margin: var(--spacing-6) 0 var(--spacing-4);
    padding-bottom: var(--spacing-2);
    border-bottom: 2px solid var(--gray-200);
}

.form-section-title:first-child {
    margin-top: 0;
}

/* Form Row for side-by-side inputs */
.form-row {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: var(--spacing-4);
    margin-bottom: var(--spacing-4);
}

@media (max-width: 767px) {
    .form-row {
        grid-template-columns: 1fr;
    }

    .profile-view-header {
        flex-direction: column;
        align-items: stretch;
    }

    .btn-preview {
        width: 100%;
        justify-content: center;
    }
}

/* Add Menu Form */
.add-menu-form .form-row {
    grid-template-columns: 1fr 1fr auto;
    align-items: end;
}

.form-group-button {
    min-width: 150px;
}

.btn-add-menu {
    display: inline-flex;
    align-items: center;
    gap: var(--spacing-2);
    padding: var(--spacing-3) var(--spacing-5);
    background: var(--gradient-primary);
    color: var(--white);
    font-size: var(--font-size-base);
    font-weight: var(--font-weight-semibold);
    border: none;
    border-radius: var(--radius-lg);
    cursor: pointer;
    transition: all var(--transition-base);
    box-shadow: 0 4px 16px rgba(102, 126, 234, 0.3);
    width: 100%;
    justify-content: center;
    min-height: 44px;
}

.btn-add-menu:hover {
    transform: translateY(-2px);
    box-shadow: 0 8px 24px rgba(102, 126, 234, 0.4);
}

.btn-add-menu .btn-icon {
    width: 18px;
    height: 18px;
}

@media (max-width: 767px) {
    .add-menu-form .form-row {
        grid-template-columns: 1fr;
    }

    .form-group-button {
        min-width: auto;
    }
}

/* ===================================
   MENU EDIT TABLE
   =================================== */
.menu-edit-table {
    width: 100%;
    border-collapse: collapse;
}

.menu-edit-table thead {
    background: var(--gray-100);
}

.menu-edit-table th {
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-900);
    padding: var(--spacing-3) var(--spacing-4);
    text-align: left;
    border-bottom: 2px solid var(--gray-200);
}

.menu-edit-table th:last-child {
    text-align: center;
}

.menu-edit-table tbody tr {
    border-bottom: 1px solid var(--gray-200);
}

.menu-edit-table tbody tr:last-child {
    border-bottom: none;
}

.menu-edit-table td {
    padding: var(--spacing-4);
    font-size: var(--font-size-base);
}

.menu-edit-table td:first-child {
    font-weight: var(--font-weight-medium);
}

.menu-edit-table td:last-child {
    text-align: center;
}

.edit-input {
    width: 100%;
    padding: 6px 12px;
    border: 1px solid var(--gray-200);
    border-radius: 4px;
    font-size: var(--font-size-base);
}

/* ===================================
   BOTTOM NAVIGATION (MOBILE)
   =================================== */
.bottom-nav {
    display: none;
}

@media (max-width: 1023px) {
    .bottom-nav {
        display: flex;
        position: fixed;
        bottom: 0;
        left: 0;
        right: 0;
        background: var(--gray-900);
        height: 60px;
        justify-content: space-around;
        align-items: center;
        z-index: 100;
    }

    .bottom-nav-item {
        flex: 1;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        gap: 4px;
        color: var(--gray-200);
        text-decoration: none;
        font-size: var(--font-size-xs);
        padding: var(--spacing-2);
    }

    .bottom-nav-item.active {
        color: var(--white);
    }

    .bottom-nav-item .nav-icon {
        font-size: var(--font-size-lg);
    }
}

/* ===================================
   TOAST NOTIFICATION
   =================================== */
.toast {
    position: fixed;
    bottom: 100px;
    left: 50%;
    transform: translateX(-50%);
    background: var(--gray-900);
    color: var(--white);
    padding: var(--spacing-4) var(--spacing-6);
    border-radius: 8px;
    font-size: var(--font-size-sm);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.3);
    opacity: 0;
    pointer-events: none;
    transition: opacity 0.3s;
    z-index: 1000;
}

.toast.show {
    opacity: 1;
    pointer-events: auto;
}

/* ===================================
   LOGIN MODAL
   =================================== */
.modal {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(15, 23, 42, 0.7);
    backdrop-filter: blur(8px);
    -webkit-backdrop-filter: blur(8px);
    z-index: 2000;
    align-items: center;
    justify-content: center;
    animation: fadeIn var(--transition-base);
}

@keyframes fadeIn {
    from {
        opacity: 0;
    }

    to {
        opacity: 1;
    }
}

.modal.show {
    display: flex;
}

.modal-content {
    background: var(--white);
    border-radius: var(--radius-xl);
    padding: var(--spacing-8);
    max-width: 400px;
    width: 90%;
    box-shadow: var(--shadow-2xl);
    animation: slideUp var(--transition-slow);
}

@keyframes slideUp {
    from {
        opacity: 0;
        transform: translateY(20px);
    }

    to {
        opacity: 1;
        transform: translateY(0);
    }
}

.modal-content h2 {
    font-size: var(--font-size-2xl);
    font-weight: var(--font-weight-bold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-6);
    text-align: center;
}

.login-buttons {
    display: flex;
    gap: var(--spacing-3);
    margin-top: var(--spacing-5);
}

.login-buttons .btn-primary {
    flex: 1;
}

.login-buttons .btn-cancel {
    flex: 1;
    min-height: 48px;
}

.password-hint {
    margin-top: var(--spacing-4);
    padding: var(--spacing-3);
    background: var(--gray-50);
    border-radius: 6px;
    text-align: center;
}

.password-hint small {
    color: var(--gray-700);
    font-size: var(--font-size-sm);
}

.password-hint strong {
    color: var(--primary-dark-blue);
    font-weight: var(--font-weight-semibold);
}

/* ===================================
   QRIS PAYMENT MODAL
   =================================== */
.qris-modal {
    max-width: 500px;
}

.qris-container {
    text-align: center;
    padding: var(--spacing-4) 0;
}

.qris-info {
    margin-bottom: var(--spacing-6);
}

.merchant-name {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-2);
}

.payment-amount {
    font-size: var(--font-size-3xl);
    font-weight: var(--font-weight-bold);
    background: var(--gradient-primary);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
}

.qris-code {
    background: var(--white);
    border: 2px solid var(--gray-200);
    border-radius: var(--radius-lg);
    padding: var(--spacing-6);
    margin: var(--spacing-6) auto;
    display: inline-block;
    box-shadow: var(--shadow-md);
}

.qris-code canvas {
    display: block;
    max-width: 100%;
    height: auto;
}

.qr-placeholder {
    text-align: center;
    padding: var(--spacing-8);
    color: var(--gray-700);
}

.qr-placeholder p {
    margin: var(--spacing-2) 0;
}

/* Payment Link Section */
.payment-link-section {
    margin: var(--spacing-6) 0;
    padding: var(--spacing-5);
    background: var(--gray-50);
    border-radius: var(--radius-lg);
}

.payment-instruction {
    font-size: var(--font-size-sm);
    color: var(--gray-900);
    margin-bottom: var(--spacing-4);
    text-align: center;
}

.btn-dana {
    display: block;
    width: 100%;
    max-width: 300px;
    margin: var(--spacing-4) auto;
    padding: var(--spacing-4) var(--spacing-6);
    background: linear-gradient(135deg, #00A8E8 0%, #0081C6 100%);
    color: var(--white);
    text-decoration: none;
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-bold);
    border-radius: var(--radius-lg);
    text-align: center;
    box-shadow: var(--shadow-md);
    transition: all var(--transition-base);
}

.btn-dana:hover {
    transform: translateY(-2px);
    box-shadow: var(--shadow-xl);
}

.payment-note {
    font-size: var(--font-size-xs);
    color: var(--gray-700);
    text-align: center;
    margin-top: var(--spacing-2);
}

.payment-divider {
    text-align: center;
    margin: var(--spacing-6) 0;
    position: relative;
}

.payment-divider::before,
.payment-divider::after {
    content: '';
    position: absolute;
    top: 50%;
    width: 40%;
    height: 1px;
    background: var(--gray-300);
}

.payment-divider::before {
    left: 0;
}

.payment-divider::after {
    right: 0;
}

.payment-divider span {
    background: var(--white);
    padding: 0 var(--spacing-3);
    color: var(--gray-700);
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-medium);
}

.qris-code-section {
    margin: var(--spacing-4) 0;
}

.payment-info-box {
    margin-top: var(--spacing-6);
    padding: var(--spacing-4);
    background: linear-gradient(135deg, rgba(0, 168, 232, 0.1) 0%, rgba(0, 129, 198, 0.1) 100%);
    border-radius: var(--radius-md);
    border: 1px solid rgba(0, 168, 232, 0.3);
}

.payment-info-box p {
    margin: var(--spacing-1) 0;
    font-size: var(--font-size-sm);
    color: var(--gray-900);
}

.payment-info-box strong {
    color: #0081C6;
}

.qris-instructions {
    margin-top: var(--spacing-6);
    padding-top: var(--spacing-6);
    border-top: 1px solid var(--gray-200);
}

.qris-instructions p {
    font-size: var(--font-size-sm);
    color: var(--gray-700);
    margin-bottom: var(--spacing-3);
}

.payment-apps {
    display: flex;
    flex-wrap: wrap;
    gap: var(--spacing-2);
    justify-content: center;
}

.app-badge {
    display: inline-block;
    padding: var(--spacing-1) var(--spacing-3);
    background: var(--gray-100);
    color: var(--gray-700);
    border-radius: var(--radius-md);
    font-size: var(--font-size-xs);
    font-weight: var(--font-weight-medium);
    border: 1px solid var(--gray-200);
}

.qris-buttons {
    display: flex;
    gap: var(--spacing-3);
    margin-top: var(--spacing-6);
}

.qris-buttons .btn-primary {
    flex: 1;
}

.qris-buttons .btn-cancel {
    flex: 1;
    min-height: 48px;
}

/* ===================================
   RATING MODAL
   =================================== */
.rating-modal {
    max-width: 500px;
    text-align: center;
}

.rating-subtitle {
    font-size: var(--font-size-sm);
    color: var(--gray-700);
    margin-bottom: var(--spacing-6);
}

.rating-stars {
    display: flex;
    justify-content: center;
    gap: var(--spacing-2);
    margin: var(--spacing-6) 0;
}

.star {
    font-size: 48px;
    color: var(--gray-300);
    cursor: pointer;
    transition: all var(--transition-base);
    user-select: none;
}

.star:hover,
.star.hover {
    color: #FFD700;
    transform: scale(1.2);
}

.star.selected {
    color: #FFD700;
    animation: starPulse 0.3s ease-out;
}

@keyframes starPulse {
    0% {
        transform: scale(1);
    }

    50% {
        transform: scale(1.3);
    }

    100% {
        transform: scale(1);
    }
}

.rating-text {
    font-size: var(--font-size-lg);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-900);
    margin-bottom: var(--spacing-6);
    min-height: 30px;
}

.feedback-section {
    margin: var(--spacing-6) 0;
    text-align: left;
}

.feedback-label {
    display: block;
    font-size: var(--font-size-sm);
    font-weight: var(--font-weight-semibold);
    color: var(--gray-700);
    margin-bottom: var(--spacing-2);
}

.feedback-input {
    width: 100%;
    padding: var(--spacing-3);
    border: 2px solid var(--gray-200);
    border-radius: var(--radius-lg);
    font-size: var(--font-size-sm);
    font-family: inherit;
    resize: vertical;
    transition: all var(--transition-base);
}

.feedback-input:focus {
    outline: none;
    border-color: #FFD700;
    box-shadow: 0 0 0 3px rgba(255, 215, 0, 0.2);
}

.rating-buttons {
    display: flex;
    gap: var(--spacing-3);
    margin-top: var(--spacing-6);
}

.rating-buttons .btn-primary {
    flex: 1;
}

.rating-buttons .btn-cancel {
    flex: 1;
    min-height: 48px;
}

/* ===================================
   UTILITY CLASSES
   =================================== */
.hidden {
    display: none !important;
}
