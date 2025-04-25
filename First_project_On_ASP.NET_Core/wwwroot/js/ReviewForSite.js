document.addEventListener('DOMContentLoaded', function () {
    const feedbackForm = document.getElementById('feedbackForm');

    if (feedbackForm) {
        feedbackForm.addEventListener('submit', function (e) {
            e.preventDefault();

            // Отримання даних з форми
            const name = document.getElementById('name').value;
            const email = document.getElementById('email').value;
            const review = document.getElementById('review').value;

            // Створення нового відгуку
            addNewReview(name, email, review);

            // Очищення форми
            feedbackForm.reset();
        });
    }
});

function addNewReview(name, email, content) {
    const reviewsList = document.querySelector('.reviews-list');

    // Створення HTML для нового відгуку
    const reviewItem = document.createElement('div');
    reviewItem.className = 'review-item';

    // Отримання поточної дати
    const currentDate = new Date();
    const formattedDate = `${currentDate.getDate().toString().padStart(2, '0')}.${(currentDate.getMonth() + 1).toString().padStart(2, '0')}.${currentDate.getFullYear()}`;

    reviewItem.innerHTML = `
        <div class="review-header">
            <span class="review-author">${name}</span>
            <span class="review-date">${formattedDate}</span>
        </div>
        <div class="review-content">
            ${content}
        </div>
        <div class="review-separator"></div>
    `;

    // Додавання нового відгуку на початок списку
    reviewsList.insertBefore(reviewItem, reviewsList.children[1]);

    // Плавний скрол до нового відгуку
    reviewItem.scrollIntoView({ behavior: 'smooth' });
}