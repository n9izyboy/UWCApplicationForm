/**
 * Form Helper Utilities
 * Provides form-specific helper functions for validation, formatting, and UX
 */

export class FormHelpers {
    /**
     * Format South African ID number (13 digits with spaces)
     */
    static formatSAIdNumber(value: string): string {
        const cleaned = value.replace(/\D/g, '');
        const match = cleaned.match(/^(\d{0,6})(\d{0,4})(\d{0,3})$/);
        if (match) {
            return [match[1], match[2], match[3]].filter(x => x).join(' ');
        }
        return value;
    }

    /**
     * Format phone number (South African format)
     */
    static formatPhoneNumber(value: string): string {
        const cleaned = value.replace(/\D/g, '');
        const match = cleaned.match(/^(\d{0,3})(\d{0,3})(\d{0,4})$/);
        if (match) {
            return [match[1], match[2], match[3]].filter(x => x).join(' ');
        }
        return value;
    }

    /**
     * Validate South African ID number
     */
    static validateSAIdNumber(idNumber: string): boolean {
        const cleaned = idNumber.replace(/\s/g, '');
        if (cleaned.length !== 13 || !/^\d+$/.test(cleaned)) {
            return false;
        }

        // Luhn algorithm check
        let sum = 0;
        for (let i = 0; i < 13; i++) {
            let digit = parseInt(cleaned.charAt(i));
            if (i % 2 === 1) {
                digit *= 2;
                if (digit > 9) {
                    digit -= 9;
                }
            }
            sum += digit;
        }
        return sum % 10 === 0;
    }

    /**
     * Validate email address
     */
    static validateEmail(email: string): boolean {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    /**
     * Auto-focus first input in a container
     */
    static autoFocusFirstInput(containerId: string): void {
        setTimeout(() => {
            const container = document.getElementById(containerId);
            if (container) {
                const firstInput = container.querySelector<HTMLInputElement>('input, select, textarea');
                if (firstInput) {
                    firstInput.focus();
                }
            }
        }, 100);
    }

    /**
     * Smooth scroll to element
     */
    static smoothScrollTo(elementId: string): void {
        const element = document.getElementById(elementId);
        if (element) {
            element.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
    }

    /**
     * Show toast notification
     */
    static showToast(message: string, type: 'success' | 'error' | 'info' = 'info', duration: number = 3000): void {
        const toast = document.createElement('div');
        toast.className = `toast ${type}`;
        toast.innerHTML = `
            <div class="flex items-center gap-3">
                <span class="text-sm font-medium">${message}</span>
                <button onclick="this.parentElement.parentElement.remove()" class="text-gray-500 hover:text-gray-700">
                    <svg class="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                        <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path>
                    </svg>
                </button>
            </div>
        `;
        document.body.appendChild(toast);

        setTimeout(() => {
            toast.classList.add('fade-out');
            setTimeout(() => toast.remove(), 300);
        }, duration);
    }

    /**
     * Show confetti animation (for successful submission)
     */
    static showConfetti(): void {
        const colors = ['#1e3a8a', '#f59e0b', '#10b981', '#ef4444', '#8b5cf6'];
        const confettiCount = 50;

        for (let i = 0; i < confettiCount; i++) {
            setTimeout(() => {
                const confetti = document.createElement('div');
                confetti.style.position = 'fixed';
                confetti.style.width = '10px';
                confetti.style.height = '10px';
                confetti.style.backgroundColor = colors[Math.floor(Math.random() * colors.length)];
                confetti.style.left = Math.random() * window.innerWidth + 'px';
                confetti.style.top = '-10px';
                confetti.style.zIndex = '10000';
                confetti.style.borderRadius = '50%';
                confetti.style.pointerEvents = 'none';
                
                document.body.appendChild(confetti);

                confetti.style.animation = `confetti ${2 + Math.random() * 2}s linear forwards`;

                setTimeout(() => confetti.remove(), 4000);
            }, i * 30);
        }
    }

    /**
     * Trigger shake animation on element
     */
    static shakeElement(elementId: string): void {
        const element = document.getElementById(elementId);
        if (element) {
            element.classList.add('shake-animation');
            setTimeout(() => element.classList.remove('shake-animation'), 500);
        }
    }

    /**
     * Get file extension
     */
    static getFileExtension(filename: string): string {
        return filename.slice((filename.lastIndexOf('.') - 1 >>> 0) + 2);
    }

    /**
     * Format file size
     */
    static formatFileSize(bytes: number): string {
        if (bytes === 0) return '0 Bytes';
        const k = 1024;
        const sizes = ['Bytes', 'KB', 'MB', 'GB'];
        const i = Math.floor(Math.log(bytes) / Math.log(k));
        return Math.round(bytes / Math.pow(k, i) * 100) / 100 + ' ' + sizes[i];
    }
}

// Global object for Blazor interop
(window as any).FormHelpers = {
    formatSAIdNumber: (value: string) => FormHelpers.formatSAIdNumber(value),
    formatPhoneNumber: (value: string) => FormHelpers.formatPhoneNumber(value),
    validateSAIdNumber: (idNumber: string) => FormHelpers.validateSAIdNumber(idNumber),
    validateEmail: (email: string) => FormHelpers.validateEmail(email),
    autoFocusFirstInput: (containerId: string) => FormHelpers.autoFocusFirstInput(containerId),
    smoothScrollTo: (elementId: string) => FormHelpers.smoothScrollTo(elementId),
    showToast: (message: string, type: 'success' | 'error' | 'info', duration: number) => 
        FormHelpers.showToast(message, type, duration),
    showConfetti: () => FormHelpers.showConfetti(),
    shakeElement: (elementId: string) => FormHelpers.shakeElement(elementId),
    formatFileSize: (bytes: number) => FormHelpers.formatFileSize(bytes)
};
