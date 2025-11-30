/**
 * LocalStorage Helper Module
 * Provides type-safe localStorage operations with JSON serialization
 */

export class LocalStorageHelper {
    /**
     * Save data to localStorage with JSON serialization
     */
    static save<T>(key: string, data: T): boolean {
        try {
            const serialized = JSON.stringify(data);
            localStorage.setItem(key, serialized);
            return true;
        } catch (error) {
            console.error(`Error saving to localStorage (key: ${key}):`, error);
            return false;
        }
    }

    /**
     * Load data from localStorage with JSON deserialization
     */
    static load<T>(key: string): T | null {
        try {
            const serialized = localStorage.getItem(key);
            if (serialized === null) {
                return null;
            }
            return JSON.parse(serialized) as T;
        } catch (error) {
            console.error(`Error loading from localStorage (key: ${key}):`, error);
            return null;
        }
    }

    /**
     * Remove item from localStorage
     */
    static remove(key: string): boolean {
        try {
            localStorage.removeItem(key);
            return true;
        } catch (error) {
            console.error(`Error removing from localStorage (key: ${key}):`, error);
            return false;
        }
    }

    /**
     * Clear all localStorage data
     */
    static clear(): boolean {
        try {
            localStorage.clear();
            return true;
        } catch (error) {
            console.error('Error clearing localStorage:', error);
            return false;
        }
    }

    /**
     * Check if key exists in localStorage
     */
    static exists(key: string): boolean {
        return localStorage.getItem(key) !== null;
    }

    /**
     * Get all keys from localStorage
     */
    static getAllKeys(): string[] {
        const keys: string[] = [];
        for (let i = 0; i < localStorage.length; i++) {
            const key = localStorage.key(i);
            if (key) {
                keys.push(key);
            }
        }
        return keys;
    }
}

// Global object for Blazor interop
(window as any).LocalStorageHelper = {
    save: (key: string, data: string): boolean => {
        try {
            localStorage.setItem(key, data);
            return true;
        } catch (error) {
            console.error('LocalStorage save error:', error);
            return false;
        }
    },

    load: (key: string): string | null => {
        try {
            return localStorage.getItem(key);
        } catch (error) {
            console.error('LocalStorage load error:', error);
            return null;
        }
    },

    remove: (key: string): boolean => {
        try {
            localStorage.removeItem(key);
            return true;
        } catch (error) {
            console.error('LocalStorage remove error:', error);
            return false;
        }
    },

    clear: (): boolean => {
        try {
            localStorage.clear();
            return true;
        } catch (error) {
            console.error('LocalStorage clear error:', error);
            return false;
        }
    },

    exists: (key: string): boolean => {
        return localStorage.getItem(key) !== null;
    }
};
