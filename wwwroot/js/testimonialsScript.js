document.addEventListener("DOMContentLoaded", function () {
    let scrollIndex = 0;
    const cardWidth = 320; // Width of each testimonial card including margin
    const container = document.querySelector(".testimonial-container");

    function scrollTestimonials(direction) {
        const maxScroll = container.scrollWidth - container.clientWidth;
        scrollIndex += direction * cardWidth;

        if (scrollIndex < 0) {
            scrollIndex = 0;
        } else if (scrollIndex > maxScroll) {
            scrollIndex = maxScroll;
        }

        container.style.transform = `translateX(-${scrollIndex}px)`;
    }

    document.querySelector(".scroll-btn.left").addEventListener("click", function () {
        scrollTestimonials(-1);
    });

    document.querySelector(".scroll-btn.right").addEventListener("click", function () {
        scrollTestimonials(1);
    });
});
