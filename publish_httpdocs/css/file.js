document.addEventListener("DOMContentLoaded", function () {
    let b1 = document.getElementById("on");
    let b2 = document.getElementById("off");
    let view = document.getElementById("view");

    if (b1 && view) {
        b1.addEventListener("click", function () {
            view.style.display = "block";
        });
    }

    if (b2 && view) {
        b2.addEventListener("click", function () {
            view.style.display = "none";
        });
    }

    document.querySelectorAll('.faqhead').forEach(head => {
        head.style.cursor = 'pointer';
        head.addEventListener('click', () => {
            const detail = head.nextElementSibling;
            const downIcon = head.querySelector('.fa-angle-down, .fa-caret-down');
            const upIcon = head.querySelector('.fa-angle-up, .fa-caret-up');
            if (detail) {
                detail.classList.toggle('show');
                const isOpen = detail.classList.contains('show');
                if (downIcon) downIcon.style.display = isOpen ? 'none' : 'inline-block';
                if (upIcon) upIcon.style.display = isOpen ? 'inline-block' : 'none';
            }
        });
    });

    window.addEventListener('scroll', () => {
        const header = document.querySelector('.newheader');
        if (header) {
            if (window.scrollY > 50) {
                header.classList.add('scrolled');
            } else {
                header.classList.remove('scrolled');
            }
        }
    });

    const currentPath = window.location.pathname;
    const navLinks = document.querySelectorAll(".navigate nav ul li a");
    navLinks.forEach(link => {
        try {
            const linkPath = new URL(link.href, window.location.origin).pathname;
            if (linkPath === currentPath) {
                link.classList.add("active");
            }
        } catch (e) {}
    });
});
