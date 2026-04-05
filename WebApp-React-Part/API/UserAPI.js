const API_BASE = 'https://localhost:7072/User';

export async function Getusers() {
    const response = await fetch(API_BASE);
    if (!response.ok) {
        throw new Error('Zlyhanie načítania používateľov');
    }
    return await response.json();
