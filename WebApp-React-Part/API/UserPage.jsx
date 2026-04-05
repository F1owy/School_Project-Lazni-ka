import { useState, useEffect } from "react";
import { Getusers } from "./UserAPI";
import UserList from "./UserList";

export default function UserPage() {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null); 

    useEffect(() => {
        setLoading(true);
        Getusers()
        .then(setUsers)
        .catch(err => setError(err.message))
        .finally(() => setLoading(false));
}, []);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return <UserList users={users} />;
}