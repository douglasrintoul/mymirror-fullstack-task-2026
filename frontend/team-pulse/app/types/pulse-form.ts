export interface PulseFormData {
	score: number | null;
	categoryId: string;
	comment: string;
}

export interface PulseCategory {
	id: string;
	name: string;
}

export interface SubmitPulseResponse {
	success: boolean;
	id: string | null;
	error: string | null;
}
