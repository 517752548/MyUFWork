
using System.Collections.Generic;

public class ChainComponent {
	public ChainComponent next;
	public virtual bool Handle() {
		if (next != null) {
			return next.Handle();
		}
		return false;
	}
}

public class VoiceMatchComponent : ChainComponent {
	public string recognition;
	public string answerWord;
	public List<string> similars;
	public List<string> answords;
	public new VoiceMatchComponent next;
	public override bool Handle()
	{
		if (next != null) {
			next.recognition = recognition;
			next.answerWord = answerWord;
			next.similars = similars;
		}
		if (next != null) {
			return next.Handle();
		}
		return false;
	}
}

