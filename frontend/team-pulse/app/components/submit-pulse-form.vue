<script setup lang="ts">
import type { PulseFormData, PulseCategory } from '~/types/pulse-form';

const props = defineProps<{
	loading: boolean;
	formSubmissionSuccessful: boolean;
	error: string;
}>();

const emit = defineEmits<{
	submit: [data: PulseFormData];
}>();

const config = useRuntimeConfig();
const { data: categories } = useFetch<PulseCategory[]>('/api/pulse/categories', {
	baseURL: config.public.apiBaseUrl,
});

const formData = reactive<PulseFormData>({
	score: null,
	categoryId: '',
	comment: '',
});

const formValid = computed(() => formData.score !== null && formData.categoryId !== '');

watch(() => props.formSubmissionSuccessful, (val) => {
	if (val) {
		formData.score = null;
		formData.categoryId = '';
		formData.comment = '';
	}
});

</script>

<template>
	<ScorePicker
		:max="5"
		:value="formData.score"
		@update:value="formData.score = $event"
	/>
	<select
		v-model="formData.categoryId"
		name="category"
	>
		<option
			selected
			disabled
			value=""
		>
			Pulse Category
		</option>
		<option
			v-for="category in categories"
			:key="category.id"
			:value="category.id"
		>
			{{ category.name }}
		</option>
	</select>
	<input
		v-model="formData.comment"
		name="comment"
		placeholder="Optional comment"
		maxlength="500"
	>
	<div>
		<p v-if="formSubmissionSuccessful">
			<Icon
				name="proicons:checkmark-circle"
				mode="svg"
			/> Pulse submitted - thank you!
		</p>
		<p
			v-if="error"
			style="color: red"
		>
			{{ error }}
		</p>
		<LoadingSpinner v-if="loading" />
	</div>
	<button
		class="submit-pulse-button"
		:disabled="loading || !formValid"
		@click="emit('submit', { ...formData })"
	>
		Submit Pulse
	</button>
</template>

<style scoped>
.submit-pulse-button {
  background-color: var(--hero-orange);
  border-color: var(--hero-orange);
  width: 100%;
  color: var(--hero-blue);
  font-weight: bold;
}
</style>
