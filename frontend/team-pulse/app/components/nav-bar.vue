<template>
    <nav>
        <ul>
            <li><strong>Team Pulse</strong></li>
        </ul>
        <ul>
            <li><NuxtLink :to="{ name: 'index' }">Submit Pulse</NuxtLink></li>
            <li><NuxtLink :to="{ name: 'summary' }">Summary</NuxtLink></li>
        </ul>
    </nav>
</template>