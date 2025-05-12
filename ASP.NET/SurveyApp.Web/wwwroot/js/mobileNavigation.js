
// Funcionalidad del menú móvil
document.addEventListener('DOMContentLoaded', function() {
    const menuToggle = document.getElementById('mobile-menu-button');
    const mobileMenu = document.getElementById('mobile-menu');
    
    if (menuToggle && mobileMenu) {
        menuToggle.addEventListener('click', function() {
            if (mobileMenu.classList.contains('hidden')) {
                // Mostrar el menú
                mobileMenu.classList.remove('hidden');

                // Agregar superposición
                const overlay = document.createElement('div');
                overlay.className = 'mobile-menu-overlay';
                document.body.appendChild(overlay);

                // Activar animación
                setTimeout(() => {
                    mobileMenu.classList.add('show');
                    overlay.classList.add('show');
                }, 10);

                // Bloquear desplazamiento del body
                document.body.style.overflow = 'hidden';

                // Registrar clic fuera para cerrar
                overlay.addEventListener('click', cerrarMenu);
            } else {
                cerrarMenu();
            }
        });
    }
    
    // Efecto de desplazamiento de la barra de navegación
    const header = document.querySelector('header nav');
    
    if (header) {
        window.addEventListener('scroll', function() {
            if (window.scrollY > 10) {
                header.classList.add('glass', 'shadow');
            } else {
                header.classList.remove('glass', 'shadow');
            }
        });
    }

    function cerrarMenu() {
        const mobileMenu = document.getElementById('mobile-menu');
        const overlay = document.querySelector('.mobile-menu-overlay');

        if (mobileMenu && !mobileMenu.classList.contains('hidden')) {
            mobileMenu.classList.remove('show');
            if (overlay) overlay.classList.remove('show');

            // Después de que se complete la animación
            setTimeout(() => {
                mobileMenu.classList.add('hidden');
                if (overlay) overlay.remove();
                // Restaurar el desplazamiento
                document.body.style.overflow = '';
            }, 300);
        }
    }
});
