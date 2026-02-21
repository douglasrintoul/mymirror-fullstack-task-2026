<script setup lang="ts">
import { Chart as ChartJS, CategoryScale, LinearScale, BarElement, type ChartData } from 'chart.js';
import { Bar } from 'vue-chartjs';
import type { TeamPulseSummary } from '~/types/pulse-summary';

ChartJS.register(CategoryScale, LinearScale, BarElement);

const props = defineProps<{
	summary: TeamPulseSummary;
}>();

const heroBlue = ref('');
const heroOrange = ref('');
onMounted(() => {
	const styles = getComputedStyle(document.documentElement);
	heroBlue.value = styles.getPropertyValue('--hero-blue').trim();
	heroOrange.value = styles.getPropertyValue('--hero-orange').trim();
});

const mostCommonScore = computed(() => {
	const entries = Object.entries(props.summary.scores);
	return entries.reduce((a, b) => (b[1] > a[1] ? b : a))[0];
});

const chartData = computed<ChartData<'bar'>>(() => {
	const values = Object.values(props.summary.scores);
	const min = Math.min(...values);
	const max = Math.max(...values);

	return {
		labels: Object.keys(props.summary.scores),
		datasets: [
			{
				label: 'Team Pulse Scores',
				// This mapping provides highlighting for the minimum and maximum value, as in the designs
				backgroundColor: values.map(v =>
					v === min || v === max ? heroOrange.value : heroBlue.value,
				),
				data: values,
			},
		],
	};
});

const chartOptions = {
	responsive: true,
	plugins: {
		legend: { display: false },
	},
	scales: {
		y: {
			ticks: { stepSize: 1 },
		},
	},
};
</script>

<template>
	<div class="summary-cards">
		<div class="summary-card-wrapper summary-card-wrapper--highlighted">
			<div class="summary-card">
				<p>Total Submissions</p>
				<span class="value">{{ summary.count }}</span>
			</div>
		</div>
		<div class="summary-card-wrapper">
			<div class="summary-card">
				<p>Average Score</p>
				<span class="value">{{ summary.averageScore }}</span>
			</div>
		</div>
		<div class="summary-card-wrapper">
			<div class="summary-card">
				<p>Most Common Score</p>
				<span class="value">{{ mostCommonScore }}</span>
			</div>
		</div>
	</div>
	<h5 style="color: var(--hero-blue);">
		Score Distribution
	</h5>

	<Bar
		:data="chartData"
		:options="chartOptions"
	/>

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
	line-height: 1.2;
	margin-bottom: 0.25rem;
	font-size: 0.8rem;
}

.summary-card .value {
	font-size: 2rem;
	font-weight: 500;
	color: var(--hero-blue);
}
</style>
