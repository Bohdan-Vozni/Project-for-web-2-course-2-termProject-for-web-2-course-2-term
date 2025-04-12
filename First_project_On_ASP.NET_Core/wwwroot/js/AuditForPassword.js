<script>
    document.querySelector('form').addEventListener('submit', function (event) {
        var password = document.getElementById('password').value;
    var confirmPassword = document.getElementById('confirmPassword').value;
    var confirmPasswordError = document.getElementById('confirmPasswordError');

    // Перевірка на співпадіння паролів
    if (password !== confirmPassword) {
        event.preventDefault(); // Запобігає відправці форми
    confirmPasswordError.style.display = 'block'; // Показуємо повідомлення про помилку
        } else {
        confirmPasswordError.style.display = 'none'; // Сховуємо помилку, якщо паролі співпадають
        }
    });
</script>
