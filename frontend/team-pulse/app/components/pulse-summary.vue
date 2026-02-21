<script setup lang="ts">
import type { TeamPulseSummary } from '~/types/pulse-summary';

const props = defineProps<{
	summary: TeamPulseSummary;
}>();

const mostCommonScore = computed(() => {
	const entries = Object.entries(props.summary.scores);
	return entries.reduce((a, b) => (b[1] > a[1] ? b : a))[0];
});
</script>

<template>
	<div class="summary-cards">
		<div class="summary-card-wrapper summary-card-wrapper--highlighted">
			<div class="summary-card">
				<p>Total Submissions</p>
				<strong>{{ summary.count }}</strong>
			</div>
		</div>
		<div class="summary-card-wrapper">
			<div class="summary-card">
				<p>Average Score</p>
				<strong>{{ summary.averageScore }}</strong>
			</div>
		</div>
		<div class="summary-card-wrapper">
			<div class="summary-card">
				<p>Most Common Score</p>
				<strong>{{ mostCommonScore }}</strong>
			</div>
		</div>
	</div>
	<h4>Score Distribution</h4>
	<p>GRAPH</p>
	<small style="color: var(--hero-blue);">Aggregated results only. Individual submissions remain anonymous.</small>
</template>

<style scoped>
.summary-cards {
	display: flex;
	gap: 1rem;
	margin-bottom: 1.5rem;
}

.summary-card-wrapper {
	flex: 1;
	padding-top: 17px;
}

.summary-card-wrapper--highlighted {
	border-top: 2px solid var(--hero-orange);
	padding-top: 15px;
}

.summary-card {
	display: flex;
	flex-direction: column;
	justify-content: center;
	text-align: center;
	height: 100%;
	padding: 0.4rem;
	border: 1px solid #eee;
	border-radius: 5px;
}

.summary-card p {
	display: block;
	margin-bottom: 0.25rem;
	font-size: 0.8rem;
}

.summary-card strong {
	font-size: 2rem;
}
</style>
