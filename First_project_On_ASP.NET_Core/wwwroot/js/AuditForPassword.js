document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('signupForm');
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirmPassword');
    const confirmPasswordError = document.getElementById('confirmPasswordError');

    form.addEventListener('submit', function (event) {
        const password = passwordInput.value.trim();
        const confirmPassword = confirmPasswordInput.value.trim();

        // Скидаємо попередню помилку
        confirmPasswordError.textContent = '';
        confirmPasswordError.style.display = 'none';

        // Перевіряємо паролі
        if (password !== confirmPassword) {
            event.preventDefault(); // Не відправляємо форму
            confirmPasswordError.textContent = 'Паролі не співпадають';
            confirmPasswordError.style.display = 'block'; // Показуємо помилку
        }
    });
});
