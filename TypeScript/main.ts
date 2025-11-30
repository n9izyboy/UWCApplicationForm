/**
 * Main TypeScript Entry Point
 * Initializes all modules and exposes them to Blazor
 */

import './swipeDetection.js';
import './localStorageHelper.js';
import './formHelpers.js';

console.log('UWC Application Form - TypeScript modules loaded');

// Export type definitions for Blazor interop
export interface WindowWithBlazorHelpers extends Window {
    SwipeDetection: any;
    LocalStorageHelper: any;
    FormHelpers: any;
}

// Ensure global objects are available
declare const window: WindowWithBlazorHelpers;
