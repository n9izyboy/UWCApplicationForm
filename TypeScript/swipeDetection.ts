/**
 * Swipe Detection Module
 * Detects left/right swipe gestures for mobile form navigation
 */

export interface SwipeEvent {
    direction: 'left' | 'right';
    distance: number;
    duration: number;
}

export class SwipeDetector {
    private touchStartX: number = 0;
    private touchStartY: number = 0;
    private touchStartTime: number = 0;
    private readonly minSwipeDistance: number = 50;
    private readonly maxSwipeTime: number = 500;
    private readonly maxVerticalDistance: number = 100;

    constructor(
        private element: HTMLElement,
        private onSwipe: (event: SwipeEvent) => void
    ) {
        this.attachListeners();
    }

    private attachListeners(): void {
        this.element.addEventListener('touchstart', this.handleTouchStart.bind(this), { passive: true });
        this.element.addEventListener('touchend', this.handleTouchEnd.bind(this), { passive: true });
    }

    private handleTouchStart(e: TouchEvent): void {
        const touch = e.touches[0];
        this.touchStartX = touch.clientX;
        this.touchStartY = touch.clientY;
        this.touchStartTime = Date.now();
    }

    private handleTouchEnd(e: TouchEvent): void {
        const touch = e.changedTouches[0];
        const touchEndX = touch.clientX;
        const touchEndY = touch.clientY;
        const touchEndTime = Date.now();

        const deltaX = touchEndX - this.touchStartX;
        const deltaY = touchEndY - this.touchStartY;
        const duration = touchEndTime - this.touchStartTime;

        // Check if it's a valid swipe
        if (
            Math.abs(deltaX) >= this.minSwipeDistance &&
            Math.abs(deltaY) <= this.maxVerticalDistance &&
            duration <= this.maxSwipeTime
        ) {
            const direction: 'left' | 'right' = deltaX > 0 ? 'right' : 'left';
            this.onSwipe({
                direction,
                distance: Math.abs(deltaX),
                duration
            });
        }
    }

    public destroy(): void {
        this.element.removeEventListener('touchstart', this.handleTouchStart.bind(this));
        this.element.removeEventListener('touchend', this.handleTouchEnd.bind(this));
    }
}

// Global function for Blazor interop
(window as any).SwipeDetection = {
    initialize: (elementId: string, dotNetHelper: any): SwipeDetector | null => {
        const element = document.getElementById(elementId);
        if (!element) {
            console.error(`Element with id '${elementId}' not found`);
            return null;
        }

        return new SwipeDetector(element, (swipeEvent) => {
            dotNetHelper.invokeMethodAsync('OnSwipe', swipeEvent.direction);
        });
    },

    destroy: (detector: SwipeDetector | null): void => {
        if (detector) {
            detector.destroy();
        }
    }
};
